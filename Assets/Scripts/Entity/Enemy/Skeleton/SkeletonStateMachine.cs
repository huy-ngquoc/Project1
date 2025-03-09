#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(SkeletonController))]
    public sealed class SkeletonStateMachine : EnemyStateMachine
    {
        public SkeletonStateMachine()
        {
            this.IdleState = new SkeletonIdleState(this);
            this.MoveState = new SkeletonMoveState(this);
        }

        [field: Header("Controller")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public SkeletonController SkeletonController { get; private set; } = null!;

        public sealed override EnemyController EnemyController => this.SkeletonController;

        public sealed override EntityState InitialState => this.IdleState;

        public SkeletonIdleState IdleState { get; }

        public SkeletonMoveState MoveState { get; }
    }
}
