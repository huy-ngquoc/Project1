#nullable enable

namespace Game;

public sealed class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerStateMachine playerStateMachine)
    {
        this.PlayerStateMachine = playerStateMachine;
    }

    public override string AnimationBoolName => AnimationBoolNameConstants.Move;

    protected override PlayerStateMachine PlayerStateMachine { get; }

    protected override void OnPlayerGroundedStateEnter()
    {
        this.PlayerController.UnityAccess(p => p.SetLinearVelocityX(this.MoveInputInt.x * p.MoveSpeed));
    }

    protected override void OnPlayerGroundedStateUpdate()
    {
        var playerStateMachine = this.PlayerStateMachine;
        var playerController = this.PlayerController;
        var moveInputX = this.MoveInputXInt;

        if (!this.IsGroundDetected)
        {
            playerStateMachine.SetStateToChangeTo(playerStateMachine.FallState);
        }
        if ((System.Math.Abs(moveInputX) > 0) && (playerController != null)
            && ((moveInputX != playerController.FacingDirection) || (!playerController.IsWallDetected)))
        {
            playerController.SetLinearVelocityX(moveInputX * playerController.MoveSpeed);
        }
        else
        {
            playerStateMachine.SetStateToChangeTo(playerStateMachine.IdleState);
        }
    }
}
