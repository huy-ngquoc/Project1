#nullable enable

namespace Game;

public sealed class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerGroundedStateMachine playerGroundedStateMachine)
    {
        this.PlayerGroundedStateMachine = playerGroundedStateMachine;
    }

    public override string AnimationBoolName => AnimationNameConstants.Bool.Idle;

    public override PlayerGroundedStateMachine PlayerGroundedStateMachine { get; }

    protected override void OnPlayerGroundedStateEnter()
    {
        this.PlayerController.SetZeroLinearVelocity();
    }

    protected override void OnPlayerGroundedStateUpdate()
    {
        var playerGroundedStateController = this.PlayerGroundedStateMachine;
        var playerController = this.PlayerController;
        var moveInputXInt = this.PlayerInputHandler.MoveInputXInt;

        if ((moveInputXInt != 0)
            && ((moveInputXInt != playerController.FacingDirection) || (!playerController.IsWallDetected)))
        {
            playerGroundedStateController.SetStateToChangeTo(playerGroundedStateController.MoveState);
        }
    }
}
