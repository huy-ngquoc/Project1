#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class SkeletonAnimationTriggers : EnemyAnimationTriggers
    {
        [field: Header("Skeleton controller")]
        [field: SerializeField]
        [field: ResolveComponentInParent("Skeleton")]
        public SkeletonController SkeletonController { get; private set; } = null!;

        public override EnemyController EnemyController => this.SkeletonController;
    }
}