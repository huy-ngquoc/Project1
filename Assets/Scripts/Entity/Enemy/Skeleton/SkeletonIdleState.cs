#nullable enable

namespace Game;

public sealed class SkeletonIdleState : SkeletonGroundedState
{
    public SkeletonIdleState(SkeletonGroundedStateMachine skeletonGroundedStateMachine)
    {
        this.SkeletonGroundedStateMachine = skeletonGroundedStateMachine;
    }

    public override string AnimationBoolName => AnimationNameConstants.Bool.Idle;

    public override SkeletonGroundedStateMachine SkeletonGroundedStateMachine { get; }

    protected override void OnSkeletonGroundedStateEnter()
    {
        this.StateTimer = this.SkeletonGeneralStateMachine.IdleTime;
    }

    protected override void OnSkeletonGroundedStateUpdate()
    {
        if (this.StateTimer <= 0)
        {
            this.SkeletonGeneralStateMachine.SetStateToChangeTo(this.SkeletonGroundedStateMachine.MoveState);
        }
    }
}
