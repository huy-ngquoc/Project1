#nullable enable

namespace Game;

public sealed class PlayerFallState : PlayerState
{
    public PlayerFallState(PlayerStateMachine playerStateMachine)
    {
        this.PlayerStateMachine = playerStateMachine;
    }

    public override string AnimationBoolName => AnimationBoolNameConstants.Fall;

    public override PlayerStateMachine PlayerStateMachine { get; }

    protected override void OnPlayerStateUpdate()
    {
        var playerStateMachine = this.PlayerStateMachine;
        var playerController = this.PlayerController;

        if (playerController.IsGroundDetected)
        {
            playerStateMachine.SetStateToChangeTo(playerStateMachine.IdleState);
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
