#nullable enable

namespace Game;

public sealed class PlayerJumpState : PlayerState
{
    public PlayerJumpState(PlayerStateMachine stateMachine, string animationBoolName)
        : base(stateMachine, animationBoolName)
    {
    }

    protected override void OnPlayerStateEnter()
    {
        this.PlayerInputHandler.UnityAccess(p => p.CancelJumpInputAction());

        var playerController = this.PlayerController;
        if (playerController != null)
        {
            playerController.SetLinearVelocityY(playerController.JumpForce);
        }
    }

    protected override void OnPlayerStateUpdate()
    {
        var playerStateMachine = this.PlayerStateMachine;
        var linearVelocityY = this.PlayerController.UnityAccessVal(p => p.GetLinearVelocityOrZeroY(), 0);
        if (linearVelocityY <= 0)
        {
            playerStateMachine.SetStateToChangeTo(playerStateMachine.FallState);
        }
    }
}
