#nullable enable

namespace Game;

public sealed class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerStateMachine playerStateMachine)
    {
        this.PlayerStateMachine = playerStateMachine;
    }

    public override string AnimationBoolName => AnimationBoolNameConstants.Move;

    public override PlayerStateMachine PlayerStateMachine { get; }

    protected override void OnPlayerGroundedStateEnter()
    {
        var playerController = this.PlayerController;
        playerController.SetLinearVelocityX(this.PlayerInputHandler.MoveInputX * playerController.MoveSpeed);
    }

    protected override void OnPlayerGroundedStateUpdate()
    {
        var playerStateMachine = this.PlayerStateMachine;
        var playerController = this.PlayerController;
        var moveInputXInt = this.PlayerInputHandler.MoveInputXInt;

        if ((moveInputXInt == 0)
            || ((moveInputXInt == playerController.FacingDirection) && playerController.IsWallDetected))
        {
            playerStateMachine.SetStateToChangeTo(playerStateMachine.IdleState);
            return;
        }

        playerController.SetLinearVelocityX(moveInputXInt * playerController.MoveSpeed);
    }
}
