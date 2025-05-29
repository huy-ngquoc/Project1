#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(SkeletonController))]
    public sealed class SkeletonGeneralStateMachine : EnemyGeneralStateMachine
    {
        public SkeletonGeneralStateMachine()
        {
            this.IdleState = new SkeletonIdleState(this);
            this.MoveState = new SkeletonMoveState(this);
            this.AttackState = new SkeletonAttackState(this);
            this.FreezeState = new SkeletonFreezeState(this);
            this.DeadState = new SkeletonDeadState(this);
        }

        [field: Header("Controller")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public SkeletonController SkeletonController { get; private set; } = null!;

        public sealed override EnemyController EnemyController => this.SkeletonController;

        public sealed override IEntityState InitialState => this.IdleState;

        public SkeletonIdleState IdleState { get; }

        public SkeletonMoveState MoveState { get; }

        public SkeletonAttackState AttackState { get; }

        public SkeletonFreezeState FreezeState { get; }

        public SkeletonDeadState DeadState { get; }

        protected override EnemyState? EnemyFreezeState => this.FreezeState;
    }
}
