#nullable enable

namespace Game;

public sealed class SkeletonMoveState : SkeletonGroundedState
{
    public SkeletonMoveState(SkeletonStateMachine skeletonStateMachine)
    {
        this.SkeletonStateMachine = skeletonStateMachine;
    }

    public override string AnimationBoolName => AnimationBoolNameConstants.Move;

    public override SkeletonStateMachine SkeletonStateMachine { get; }

    protected override void OnSkeletonGroundedStateUpdate()
    {
        var controller = this.SkeletonController;

        if ((!controller.IsGroundDetected) || controller.IsWallDetected)
        {
            controller.Flip();
            this.SkeletonStateMachine.SetStateToChangeTo(this.SkeletonStateMachine.IdleState);
            return;
        }

        controller.SetLinearVelocityX(controller.MoveSpeed * controller.FacingDirection);
    }
}
