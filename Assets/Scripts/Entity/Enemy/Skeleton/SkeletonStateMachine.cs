#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class SkeletonStateMachine : EnemyStateMachine
    {
        public SkeletonStateMachine()
        {
            this.SkeletonIdleState = new SkeletonIdleState(this);

            this.SetStateToChangeTo(this.SkeletonIdleState);
        }

        public SkeletonIdleState SkeletonIdleState { get; }

        [field: SerializeReference]
        [field: ResolveComponentInChildren]
        public SkeletonController? SkeletonController { get; private set; } = null;

        public sealed override EnemyController? EnemyController => this.SkeletonController;
    }
}
