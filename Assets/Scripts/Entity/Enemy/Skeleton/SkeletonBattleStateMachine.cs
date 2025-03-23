#nullable enable

namespace Game;

public sealed class SkeletonBattleStateMachine : SkeletonSpecificStateMachine
{
    public SkeletonBattleStateMachine(SkeletonGeneralStateMachine skeletonGeneralStateMachine)
    {
        this.SkeletonGeneralStateMachine = skeletonGeneralStateMachine;

        this.IdleState = new SkeletonBattleIdleState(this);
        this.MoveState = new SkeletonBattleMoveState(this);
        this.AttackState = new SkeletonBattleAttackState(this);
    }

    public override SkeletonGeneralStateMachine SkeletonGeneralStateMachine { get; }

    public override IEntityState InitialState => this.MoveState;

    public SkeletonBattleIdleState IdleState { get; }

    public SkeletonBattleMoveState MoveState { get; }

    public SkeletonBattleAttackState AttackState { get; }
}