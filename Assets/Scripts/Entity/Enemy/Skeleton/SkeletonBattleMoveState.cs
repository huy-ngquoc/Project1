#nullable enable

namespace Game;
public sealed class SkeletonBattleMoveState : SkeletonBattleState
{
    public SkeletonBattleMoveState(SkeletonBattleStateMachine skeletonBattleStateMachine)
    {
        this.SkeletonBattleStateMachine = skeletonBattleStateMachine;
    }

    public override SkeletonBattleStateMachine SkeletonBattleStateMachine { get; }

    public override string AnimationBoolName => AnimationNameConstants.Bool.Move;

    protected override void OnSkeletonBattleStateUpdate()
    {
        var playerRaycastHit2D = this.SkeletonController.IsPlayerDetected;
        if (!playerRaycastHit2D)
        {
            this.SkeletonGeneralStateMachine.SetStateToChangeTo(this.SkeletonGeneralStateMachine.GroundedState);
            return;
        }

        if (playerRaycastHit2D.distance <= this.SkeletonController.AttackRange)
        {
            this.SkeletonBattleStateMachine.SetStateToChangeTo(this.SkeletonBattleStateMachine.AttackState);
            return;
        }

        var controller = this.SkeletonController;

        if ((!controller.IsGroundDetected) || controller.IsWallDetected)
        {
            this.SkeletonController.Flip();
            this.SkeletonGeneralStateMachine.SetStateToChangeTo(this.SkeletonGeneralStateMachine.GroundedState);
            return;
        }

        controller.SetLinearVelocityX(controller.MoveSpeed * controller.FacingDirection);
    }
}