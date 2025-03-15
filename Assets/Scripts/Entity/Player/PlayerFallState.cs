#nullable enable

namespace Game;

public sealed class PlayerFallState : PlayerState
{
    public PlayerFallState(PlayerGeneralStateMachine playerGeneralStateMachine)
    {
        this.PlayerGeneralStateMachine = playerGeneralStateMachine;
    }

    public override string AnimationBoolName => AnimationNameConstants.Bool.Fall;

    public override PlayerGeneralStateMachine PlayerGeneralStateMachine { get; }

    protected override void OnPlayerStateUpdate()
    {
        var playerGeneralStateMachine = this.PlayerGeneralStateMachine;
        var playerController = this.PlayerController;

        if (playerController.IsGroundDetected)
        {
            playerGeneralStateMachine.SetStateToChangeTo(playerGeneralStateMachine.GroundedState);
            return;
        }

        if (playerController.IsWallDetected)
        {
            playerController.SetZeroLinearVelocityX();
            return;
        }

        playerController.SetLinearVelocityX(playerController.MoveSpeed * 0.8F * this.PlayerInputHandler.MoveInputX);
    }
}
