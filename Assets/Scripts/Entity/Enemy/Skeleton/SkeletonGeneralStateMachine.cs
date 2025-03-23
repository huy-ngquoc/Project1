#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(SkeletonController))]
    public sealed class SkeletonGeneralStateMachine : EnemyGeneralStateMachine
    {
        public SkeletonGeneralStateMachine()
        {
            this.GroundedState = new SkeletonGroundedStateMachine(this);
            this.BattleState = new SkeletonBattleStateMachine(this);
        }

        [field: Header("Controller")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public SkeletonController SkeletonController { get; private set; } = null!;

        public sealed override EnemyController EnemyController => this.SkeletonController;

        public sealed override IEntityState InitialState => this.GroundedState;

        public SkeletonGroundedStateMachine GroundedState { get; }

        public SkeletonBattleStateMachine BattleState { get; }
    }
}
