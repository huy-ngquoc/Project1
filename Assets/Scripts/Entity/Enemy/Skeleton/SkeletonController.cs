#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(SkeletonStateMachine))]
    public sealed class SkeletonController : EnemyController
    {
        [field: Header("State machine")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public SkeletonStateMachine SkeletonStateMachine { get; private set; } = null!;

        public sealed override EnemyStateMachine EnemyStateMachine => this.SkeletonStateMachine;
    }
}
