#nullable enable

namespace Game;

public sealed class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerGroundedStateMachine playerGroundedStateController)
    {
        this.PlayerGroundedStateMachine = playerGroundedStateController;
    }

    public override string AnimationBoolName => AnimationNameConstants.Bool.Move;

    public override PlayerGroundedStateMachine PlayerGroundedStateMachine { get; }

    protected override void OnPlayerGroundedStateEnter()
    {
        var playerController = this.PlayerController;
        playerController.SetLinearVelocityX(this.PlayerInputHandler.MoveInputX * playerController.MoveSpeed);
    }

    protected override void OnPlayerGroundedStateUpdate()
    {
        var playerGroundedStateController = this.PlayerGroundedStateMachine;
        var playerController = this.PlayerController;
        var moveInputXInt = this.PlayerInputHandler.MoveInputXInt;

        if ((moveInputXInt == 0)
            || ((moveInputXInt == playerController.FacingDirection) && playerController.IsWallDetected))
        {
            playerGroundedStateController.SetStateToChangeTo(playerGroundedStateController.IdleState);
            return;
        }

        playerController.SetLinearVelocityX(moveInputXInt * playerController.MoveSpeed);
    }
}
