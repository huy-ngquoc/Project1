#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerThrowSpinSwordSkillController : PlayerThrowSwordSkillController
    {
        [field: Header("Spin info")]

        public float MaxTravelDistance { get; private set; } = 10;

        public float SpinDuration { get; private set; } = 1;

        public float SpinTimmer { get; private set; } = 0;

        public bool WasStoppedSpinning { get; private set; } = false;

        public bool IsSpinning { get; private set; } = false;

        public float HitTimer { get; private set; } = 0;

        public float HitCooldown { get; private set; } = 0;

        public Vector2 SpinDirection { get; private set; } = Vector2.zero;

        public void SetupSpin(float maxTravelDistance, float spinDuration, float hitCooldown)
        {
            this.IsSpinning = true;
            this.MaxTravelDistance = maxTravelDistance;
            this.SpinDuration = spinDuration;
            this.HitCooldown = hitCooldown;

            this.SpinDirection = this.Rigidbody2D.linearVelocity.normalized;
        }

        protected override void OnPlayerThrowSwordSkillControllerUpdate()
        {
            if (!this.IsSpinning || !this.CanRotate)
            {
                this.IsReturning = true;
                return;
            }

            if (!this.WasStoppedSpinning)
            {
                if (Vector2.Distance(this.PlayerController.transform.position, this.transform.position) > this.MaxTravelDistance)
                {
                    this.StopWhenSpinning();
                }

                return;
            }

            this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(this.transform.position.x + this.SpinDirection.x, this.transform.position.y + this.SpinDirection.y), 1.5F * Time.deltaTime);

            if (this.SpinTimmer > Time.deltaTime)
            {
                this.SpinTimmer -= Time.deltaTime;
            }
            else
            {
                this.SpinTimmer = 0;
                this.IsSpinning = false;
                this.IsReturning = true;
            }

            if (this.HitTimer > Time.deltaTime)
            {
                this.HitTimer -= Time.deltaTime;
            }
            else
            {
                this.HitTimer = this.HitCooldown;

                var colliders = Physics2D.OverlapCircleAll(this.transform.position, 1);
                foreach (var hit in colliders)
                {
                    if (hit.TryGetComponent<EnemyController>(out var enemyController))
                    {
                        this.SwordSkillDamage(enemyController);
                    }
                }
            }
        }

        protected override void OnSwordHitEnemy(EnemyController enemyController)
        {
            if (this.IsSpinning)
            {
                this.StopWhenSpinning();
                return;
            }

            this.StuckIntoObject(enemyController.transform);
        }

        private void StopWhenSpinning()
        {
            this.WasStoppedSpinning = true;
            this.Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePosition;
            this.SpinTimmer = this.SpinDuration;
        }
    }
}
