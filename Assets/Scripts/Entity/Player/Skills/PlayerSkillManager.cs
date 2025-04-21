#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(PlayerController))]
    public sealed class PlayerSkillManager : EntitySkillManager
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerController PlayerController { get; private set; } = null!;

        public override EntityController EntityController => this.PlayerController;

        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerPrimaryAttackSkill PrimaryAttackSkill { get; private set; } = null!;

        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerDashSkill DashSkill { get; private set; } = null!;

        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerThrowSwordSkillManager ThrowSwordSkill { get; private set; } = null!;

        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerCloneSkill CloneSkill { get; private set; } = null!;

        public Transform? FindClosestEnemyTransform(Vector2 positionToCheck)
        {
            var collider = Physics2D.OverlapCircleAll(positionToCheck, 25, this.PlayerController.AttackTargetLayerMask);
            Transform? closestEnemyTransform = null;
            var closetDistance = float.PositiveInfinity;

            foreach (var hit in collider)
            {
                if (hit.TryGetComponent<EnemyController>(out var enemyController))
                {
                    var distanceToEnemy = Vector2.Distance(positionToCheck, enemyController.transform.position);

                    if (closetDistance > distanceToEnemy)
                    {
                        closestEnemyTransform = enemyController.transform;
                        closetDistance = distanceToEnemy;
                    }
                }
            }

            return closestEnemyTransform;
        }
    }
}
