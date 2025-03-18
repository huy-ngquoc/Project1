#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(SkeletonController))]
    public sealed class SkeletonStats : EnemyStats
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        public SkeletonController SkeletonController { get; private set; } = null!;

        public sealed override EnemyController EnemyController => this.SkeletonController;

        protected override void OnEnemyTakeDamage()
        {
            Debug.Log("Skeleton is damaged!");
        }
    }
}