#nullable enable

namespace Game;

public sealed class SkeletonGroundedStateMachine : SkeletonSpecificStateMachine
{
    public SkeletonGroundedStateMachine(SkeletonGeneralStateMachine skeletonGeneralStateMachine)
    {
        this.SkeletonGeneralStateMachine = skeletonGeneralStateMachine;

        this.IdleState = new SkeletonIdleState(this);
        this.MoveState = new SkeletonMoveState(this);
    }

    public override SkeletonGeneralStateMachine SkeletonGeneralStateMachine { get; }

    public override IEntityState InitialState => this.IdleState;

    public SkeletonIdleState IdleState { get; }

    public SkeletonMoveState MoveState { get; }
}