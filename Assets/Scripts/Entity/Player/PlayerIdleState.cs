#nullable enable

namespace Game;

public sealed class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine)
    {
        this.PlayerStateMachine = playerStateMachine;
    }

    public override string AnimationBoolName => AnimationBoolNameConstants.Idle;

    public override PlayerStateMachine PlayerStateMachine { get; }

    protected override void OnPlayerGroundedStateEnter()
    {
        this.PlayerController.SetZeroLinearVelocity();
    }

    protected override void OnPlayerGroundedStateUpdate()
    {
        var playerStateMachine = this.PlayerStateMachine;
        var playerController = this.PlayerController;
        var moveInputXInt = this.PlayerInputHandler.MoveInputXInt;

        if ((moveInputXInt != 0)
            && ((moveInputXInt != playerController.FacingDirection) || (!playerController.IsWallDetected)))
        {
            playerStateMachine.SetStateToChangeTo(playerStateMachine.MoveState);
        }
    }
}
