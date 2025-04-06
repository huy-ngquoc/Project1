#nullable enable

namespace Game;

public sealed class SkeletonMoveState : SkeletonState
{
    public SkeletonMoveState(SkeletonGeneralStateMachine skeletonGeneralStateMachine)
    {
        this.SkeletonGeneralStateMachine = skeletonGeneralStateMachine;
    }

    public override string AnimationBoolName => AnimationNameConstants.Bool.Move;

    public override SkeletonGeneralStateMachine SkeletonGeneralStateMachine { get; }

    protected override void OnSkeletonStateUpdate()
    {
        var controller = this.SkeletonController;
        if ((!controller.IsGroundDetected) || controller.IsWallDetected)
        {
            controller.Flip();
            this.SkeletonGeneralStateMachine.SetStateToChangeTo(this.SkeletonGeneralStateMachine.IdleState);
            return;
        }

        var playerRaycastHit2D = this.SkeletonController.IsPlayerDetected;
        if (playerRaycastHit2D
            && (playerRaycastHit2D.distance <= this.SkeletonController.AttackRange))
        {
            if (!this.SkeletonSkillManager.AttackSkill.Cast())
            {
                this.SkeletonGeneralStateMachine.SetStateToChangeTo(this.SkeletonGeneralStateMachine.IdleState);
            }
            return;
        }

        controller.SetLinearVelocityX(controller.MoveSpeed * controller.FacingDirection);
    }
}
