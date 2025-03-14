#nullable enable

namespace Game;

public sealed class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerGeneralStateMachine playerGeneralStateMachine)
    {
        this.PlayerGeneralStateMachine = playerGeneralStateMachine;
    }

    public override string AnimationBoolName => AnimationBoolNameConstants.Jump;

    public override PlayerGeneralStateMachine PlayerGeneralStateMachine { get; }

    protected override void OnPlayerStateEnter()
    {
        this.PlayerInputHandler.CancelJumpInputAction();

        var playerController = this.PlayerController;
        playerController.SetLinearVelocityY(playerController.JumpForce);
    }

    protected override void OnPlayerStateUpdate()
    {
        var playerGeneralStateMachine = this.PlayerGeneralStateMachine;
        var playerController = this.PlayerController;
        var linearVelocityY = playerController.GetLinearVelocity().y;

        if (linearVelocityY <= 0)
        {
            playerGeneralStateMachine.SetStateToChangeTo(playerGeneralStateMachine.FallState);
            return;
        }

        playerController.SetLinearVelocityX(playerController.MoveSpeed * 0.8F * this.PlayerInputHandler.MoveInputX);
    }
}
