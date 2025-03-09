#nullable enable

namespace Game;

public sealed class SkeletonIdleState : SkeletonGroundedState
{
    public SkeletonIdleState(SkeletonStateMachine skeletonStateMachine)
    {
        this.SkeletonStateMachine = skeletonStateMachine;
    }

    public override string AnimationBoolName => AnimationBoolNameConstants.Idle;

    protected override SkeletonStateMachine SkeletonStateMachine { get; }

    protected override void OnSkeletonGroundedStateEnter()
    {
        this.StateTimer = this.SkeletonStateMachine.IdleTime;
    }

    protected override void OnSkeletonGroundedStateUpdate()
    {
        if (this.StateTimer <= 0)
        {
            this.SkeletonStateMachine.SetStateToChangeTo(this.SkeletonStateMachine.SkeletonMoveState);
        }
    }
}
