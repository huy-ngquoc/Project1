#nullable enable

using UnityEngine;

namespace Game
{
    public class PlayerCrystalSkillController : PlayerSkillController
    {
        [field: SerializeField]
        [field: ResolveComponent]
        private Animator animator = null!;

        [field: SerializeField]
        [field: ResolveComponent]
        private CircleCollider2D circileCollider2D = null!;

        private Transform? selectedEnemyTransform = null;

        public float CrystalExistTimer { get; private set; } = 0;

        public bool CanExplode { get; private set; } = false;

        public bool CanMove { get; private set; } = false;

        public float MoveSpeed { get; private set; } = 0;

        public bool CanGrow { get; private set; } = false;

        public float GrowSpeed { get; private set; } = 5;

        public bool IsFinishing { get; private set; } = false;

        public LayerMask WhatIsEnemy { get; private set; }

        public void SetupCrystal(PlayerController playerController, float crystalDuration, bool canExplode, bool canMove, float moveSpeed, Transform? selectedEmenyTransform)
        {
            this.PlayerController = playerController;
            this.WhatIsEnemy = this.PlayerController.AttackTargetLayerMask;
            this.CrystalExistTimer = crystalDuration;
            this.CanExplode = canExplode;
            this.CanMove = canMove;
            this.MoveSpeed = moveSpeed;
            this.selectedEnemyTransform = selectedEmenyTransform;
        }

        public void CrystalFinishing()
        {
            this.IsFinishing = true;
            if (this.CanExplode && (this.animator != null))
            {
                this.CanGrow = true;
                this.CanMove = false;
                this.animator.SetTrigger("Explode");
            }
            else
            {
                this.SelfDestroy();
            }
        }

        protected override void OnPlayerSkillControllerUpdate()
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

            if (this.CanMove && (this.selectedEnemyTransform != null))
            {
                this.transform.position = Vector2.MoveTowards(this.transform.position, this.selectedEnemyTransform.position, this.MoveSpeed * Time.deltaTime);

                if (Vector2.Distance(this.transform.position, this.selectedEnemyTransform.position) < 1)
                {
                    this.CrystalFinishing();
                }
            }

            if (this.CanGrow)
            {
                this.transform.localScale = Vector2.Lerp(this.transform.localScale, new Vector2(3, 3), this.GrowSpeed * Time.deltaTime);
            }
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
