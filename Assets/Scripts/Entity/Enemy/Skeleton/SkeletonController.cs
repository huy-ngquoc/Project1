#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(SkeletonGeneralStateMachine))]
    public sealed class SkeletonController : EnemyController
    {
        [field: Header("State machine")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public SkeletonGeneralStateMachine SkeletonGeneralStateMachine { get; private set; } = null!;

        public sealed override EnemyGeneralStateMachine EnemyGeneralStateMachine => this.SkeletonGeneralStateMachine;
    }
}
