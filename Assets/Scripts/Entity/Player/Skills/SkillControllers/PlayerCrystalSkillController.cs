#nullable enable

namespace Game
{
    using UnityEngine;

    public abstract class PlayerCrystalSkillController : MonoBehaviour
    {
        [field: SerializeField]
        [field: ResolveComponent]
        private Animator animator = null!;

        [field: SerializeField]
        [field: ResolveComponent]
        private CircleCollider2D circileCollider2D = null!;

        public float CrystalExistTimer { get; private set; } = 0;

        public bool CanGrow { get; private set; } = false;

        public float GrowSpeed { get; private set; } = 5;

        public bool IsFinishing { get; private set; } = false;

        public LayerMask WhatIsEnemy { get; private set; }

        public PlayerController PlayerController { get; private set; } = null!;

        public void SetupCrystal(PlayerController playerController, float crystalDuration)
        {
            this.PlayerController = playerController;
            this.WhatIsEnemy = this.PlayerController.AttackTargetLayerMask;
            this.CrystalExistTimer = crystalDuration;
        }

        public virtual void CrystalFinishing()
        {
            this.IsFinishing = true;
            if (this.animator != null)
            {
                this.CanGrow = true;
                this.animator.SetTrigger("Explode");
            }
            else
            {
                this.SelfDestroy();
            }
        }

        protected void Update()
        {
            if (this.CrystalExistTimer > Time.deltaTime)
            {
                this.CrystalExistTimer -= Time.deltaTime;
            }
            else
            {
                this.CrystalExistTimer = 0;

                this.CrystalFinishing();
            }

            if (this.CanGrow)
            {
                this.transform.localScale = Vector2.Lerp(this.transform.localScale, new Vector2(3, 3), this.GrowSpeed * Time.deltaTime);
            }

            this.OnPlayerCrystalSkillControllerUpdate();
        }

        protected virtual void OnPlayerCrystalSkillControllerUpdate()
        {
            // Leave this method blank
            // The derived classes can decide if they override this method
        }

        private void AnimationExplodeEvent()
        {
            if (this.circileCollider2D != null)
            {
                var colliders = Physics2D.OverlapCircleAll(this.transform.position, this.circileCollider2D.radius);

                foreach (var hit in colliders)
                {
                    if (hit.TryGetComponent<EntityStats>(out var targetStats))
                    {
                        targetStats.EntityController.DoTakeDamageEffect(
                            (this.transform.position.x > hit.transform.position.x) ? -1 : 1,
                            this.PlayerController.KnockbackDirection,
                            this.PlayerController.KnockbackDuration);
                    }
                }
            }
        }

        private void SelfDestroy() => Object.Destroy(this.gameObject);
    }
}
