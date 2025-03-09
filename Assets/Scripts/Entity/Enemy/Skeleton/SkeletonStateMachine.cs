#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class SkeletonStateMachine : EnemyStateMachine
    {
        public SkeletonStateMachine()
        {
            this.SkeletonIdleState = new SkeletonIdleState(this);
            this.SkeletonMoveState = new SkeletonMoveState(this);

            this.SetStateToChangeTo(this.SkeletonIdleState);
        }

        [field: Header("Controller")]
        [field: SerializeReference]
        [field: ResolveComponentInChildren]
        public SkeletonController? SkeletonController { get; private set; } = null;

        public SkeletonIdleState SkeletonIdleState { get; }

        public SkeletonMoveState SkeletonMoveState { get; }

        public sealed override EnemyController? EnemyController => this.SkeletonController;
    }
}
