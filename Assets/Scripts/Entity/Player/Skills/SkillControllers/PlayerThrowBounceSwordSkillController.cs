#nullable enable

namespace Game
{
    using System.Collections.Generic;
    using UnityEngine;

    public sealed class PlayerThrowBounceSwordSkillController : PlayerThrowSwordSkillController
    {
        private readonly List<Transform> targetTransforms = new();
        private int targetIndex = 0;

        [field: Header("Bounce info")]

        public float BounceSpeed { get; private set; } = 10;

        public int BounceAmount { get; private set; } = 4;

        public float BounceDistance { get; private set; } = 16;

        public int BounceCounter { get; private set; } = 0;

        public void SetupBounce(int amountOfBounces, float bounceSpeed, float bounceDistance)
        {
            this.BounceAmount = amountOfBounces;
            this.BounceSpeed = bounceSpeed;
            this.BounceDistance = bounceDistance;

            this.targetTransforms.Capacity = this.BounceAmount;
        }

        protected override void OnReturingSword()
        {
            this.targetTransforms.Clear();
        }

        protected override void OnAwake()
        {
        }

        protected override void OnUpdate()
        {
            if (this.IsReturning || (this.targetTransforms.Count <= 0))
            {
                return;
            }

            if (this.targetTransforms[this.targetIndex] == null)
            {
                this.IsReturning = true;
                return;
            }

            this.transform.position = Vector2.MoveTowards(this.transform.position, this.targetTransforms[this.targetIndex].position, this.BounceSpeed * Time.deltaTime);

            if (Vector2.Distance(this.transform.position, this.targetTransforms[this.targetIndex].position) >= 0.1F)
            {
                return;
            }

            if (this.targetTransforms[this.targetIndex].TryGetComponent<EnemyController>(out var enemyController))
            {
                this.SwordSkillDamage(enemyController);
            }

            ++this.BounceCounter;
            if (this.BounceCounter <= this.BounceAmount)
            {
                ++this.targetIndex;

                if (this.targetIndex >= this.targetTransforms.Count)
                {
                    this.targetIndex = 0;
                }
            }
            else
            {
                this.IsReturning = true;
            }
        }

        protected override void OnSwordHitEnemy(EnemyController enemyController)
        {
            if (!this.IsReturning && (this.targetTransforms.Count <= 0))
            {
                var colliders = Physics2D.OverlapCircleAll(enemyController.transform.position, 10);
                foreach (var hit in colliders)
                {
                    if (hit.TryGetComponent<EnemyController>(out _))
                    {
                        this.targetTransforms.Add(hit.transform);
                    }
                }
            }

            this.StopRotating();
        }
    }
}
