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
        this.PlayerController.SetLinearVelocityY(this.PlayerController.JumpForce);
    }

    protected override void OnPlayerStateUpdate()
    {
        var linearVelocityY = this.PlayerController.GetLinearVelocityOrZeroY();
        if (linearVelocityY <= 0)
        {
            this.PlayerStateMachine?.ChangeState(this.PlayerStateMachine.FallState);
        }
    }
}
