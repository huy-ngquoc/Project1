#nullable enable

namespace Game;

public sealed class SkeletonMoveState : SkeletonGroundedState
{
    public SkeletonMoveState(SkeletonGroundedStateMachine skeletonGroundedStateMachine)
    {
        this.SkeletonGroundedStateMachine = skeletonGroundedStateMachine;
    }

    public override string AnimationBoolName => AnimationBoolNameConstants.Move;

    public override SkeletonGroundedStateMachine SkeletonGroundedStateMachine { get; }

    protected override void OnSkeletonGroundedStateUpdate()
    {
        var controller = this.SkeletonController;

        if ((!controller.IsGroundDetected) || controller.IsWallDetected)
        {
            controller.Flip();
            this.SkeletonGeneralStateMachine.SetStateToChangeTo(this.SkeletonGroundedStateMachine.IdleState);
            return;
        }

        controller.SetLinearVelocityX(controller.MoveSpeed * controller.FacingDirection);
    }
}
