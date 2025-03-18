#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(SkeletonGeneralStateMachine))]
    public sealed class SkeletonController : EnemyController
    {
        [field: Header("Skeleton State machine")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public SkeletonGeneralStateMachine SkeletonGeneralStateMachine { get; private set; } = null!;

        public sealed override EnemyGeneralStateMachine EnemyGeneralStateMachine => this.SkeletonGeneralStateMachine;

        [field: Header("Skeleton Stats")]
        [field: SerializeField]
        [field: ResolveComponent]
        public SkeletonStats SkeletonStats { get; private set; } = null!;

        public override EnemyStats EnemyStats => this.SkeletonStats;
    }
}
