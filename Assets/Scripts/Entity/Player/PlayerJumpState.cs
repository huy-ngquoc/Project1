#nullable enable

namespace Game;

public sealed class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerStateMachine playerStateMachine)
    {
        this.PlayerStateMachine = playerStateMachine;
    }

    public override string AnimationBoolName => AnimationBoolNameConstants.Jump;

    public override PlayerStateMachine PlayerStateMachine { get; }

    protected override void OnPlayerStateEnter()
    {
        this.PlayerInputHandler.CancelJumpInputAction();

        var playerController = this.PlayerController;
        playerController.SetLinearVelocityY(playerController.JumpForce);
    }

    protected override void OnPlayerStateUpdate()
    {
        var playerStateMachine = this.PlayerStateMachine;
        var playerController = this.PlayerController;
        var linearVelocityY = playerController.GetLinearVelocity().y;

        if (linearVelocityY <= 0)
        {
            playerStateMachine.SetStateToChangeTo(playerStateMachine.FallState);
        }

        playerController.SetLinearVelocityX(playerController.MoveSpeed * 0.8F * this.PlayerInputHandler.MoveInputX);
    }
}
