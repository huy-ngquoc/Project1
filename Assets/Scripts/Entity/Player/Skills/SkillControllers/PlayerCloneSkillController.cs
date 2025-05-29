#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerCloneSkillController : MonoBehaviour
    {
        private readonly string[] animationBoolNames = new string[]
        {
            AnimationNameConstants.Bool.PlayerClone.Attack1,
            AnimationNameConstants.Bool.PlayerClone.Attack2,
            AnimationNameConstants.Bool.PlayerClone.Attack3,
        };

        [field: SerializeField]
        [field: ResolveComponent]
        private SpriteRenderer spriteRenderer = null!;

        [field: SerializeField]
        [field: ResolveComponent]
        private Animator animator = null!;

        [field: SerializeField]
        [field: ResolveComponentInChildren("AttackCheck")]
        private Transform attackCheck = null!;

        public PlayerController PlayerController { get; private set; } = null!;

        [field: SerializeField]
        [field: Range(0.5F, 5)]
        public float ColorLoosingSpeed { get; private set; } = 1;

        public float CloneTimer { get; private set; } = 0;

        [field: SerializeField]
        [field: Range(0.1F, 5)]
        public float AttackCheckRadius { get; private set; } = 0.8F;

        public sbyte FacingDirection { get; private set; } = 1;

        public Vector2? SelectedEmenyPosition { get; private set; } = null;

        public void SetUpClone(PlayerController playerController, Vector2 position, float cloneDuration, bool cloneCanAttack, Vector2? selectedEmenyPosition)
        {
            this.PlayerController = playerController;
            this.transform.position = position;
            this.CloneTimer = cloneDuration;
            this.SelectedEmenyPosition = selectedEmenyPosition;

            if (cloneCanAttack)
            {
                this.FaceCloseTarget();
                this.animator.SetBool(this.animationBoolNames[Random.Range(0, this.animationBoolNames.Length)], true);
            }
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;

            if (this.CloneTimer > deltaTime)
            {
                this.CloneTimer -= deltaTime;
            }
            else
            {
                this.CloneTimer = 0;
            }

            if (this.CloneTimer <= 0)
            {
                this.spriteRenderer.color = new Color(
                    this.spriteRenderer.color.r,
                    this.spriteRenderer.color.g,
                    this.spriteRenderer.color.b,
                    this.spriteRenderer.color.a - (deltaTime * this.ColorLoosingSpeed));

                if (this.spriteRenderer.color.a <= 0)
                {
                    Object.Destroy(this.gameObject);
                }
            }
        }

        private void CloneAnimationTrigger()
        {
            this.CloneTimer = 0;
        }

        private bool CloneAttackTrigger()
        {
            var colliders = Physics2D.OverlapCircleAll(this.attackCheck.position, this.AttackCheckRadius);
            foreach (var hit in colliders)
            {
                if (hit.TryGetComponent<EnemyController>(out var enemyController))
                {
                    this.PlayerController.PlayerStats.DoDamage(enemyController.EntityStats);
                }
                if(hit.TryGetComponent<HealthController>(out var healthController)) {
                    healthController.TakeDamage(healthController.TakeDamageAt(1));
                }
            }

            return true;
        }

        private void FaceCloseTarget()
        {
            if ((this.SelectedEmenyPosition != null) && (this.SelectedEmenyPosition.Value.x < this.transform.position.x))
            {
                this.FacingDirection = -1;
                this.transform.Rotate(0, 180, 0);
            }
        }
    }
}
