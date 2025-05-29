#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerMultiCrystalSkillController : MonoBehaviour
    {
        [field: SerializeField]
        [field: ResolveComponent]
        private Animator animator = null!;

        [field: SerializeField]
        [field: ResolveComponent]
        private CircleCollider2D circileCollider2D = null!;

        private Transform? selectedEnemyTransform = null;

        public bool CanMove { get; private set; } = true;

        public float MoveSpeed { get; private set; } = 0;

        public float CrystalExistTimer { get; private set; } = 0;

        public bool CanGrow { get; private set; } = false;

        public float GrowSpeed { get; private set; } = 5;

        public bool IsFinishing { get; private set; } = false;

        public PlayerController? PlayerController { get; private set; } = null;

        public void SetupCrystal(PlayerController playerController, float crystalDuration, float moveSpeed, Transform? selectedEnemyTransform)
        {
            this.PlayerController = playerController;
            this.CrystalExistTimer = crystalDuration;
            this.CanMove = true;
            this.MoveSpeed = moveSpeed;
            this.selectedEnemyTransform = selectedEnemyTransform;
        }

        public void CrystalFinishing()
        {
            this.IsFinishing = true;
            if (this.animator == null)
            {
                this.SelfDestroy();
                return;
            }

            this.CanGrow = true;
            this.CanMove = false;
            this.animator.SetTrigger("Explode");
        }

        private void Update()
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
            if ((this.circileCollider2D == null) || (this.PlayerController == null))
            {
                return;
            }

            var colliders = Physics2D.OverlapCircleAll(this.transform.position, this.circileCollider2D.radius);

            foreach (var hit in colliders)
            {
                if (hit.TryGetComponent<EntityStats>(out var targetStats))
                {
                    this.PlayerController.PlayerStats.DoDamage(targetStats);
                }
                if(hit.TryGetComponent<HealthController>(out var healthController)) {
                    healthController.TakeDamage(healthController.TakeDamageAt(3));
                }
            }
        }

        private void SelfDestroy() => Object.Destroy(this.gameObject);
    }
}
