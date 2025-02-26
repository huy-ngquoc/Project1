#nullable enable

namespace Game;

public sealed class PlayerFallState : PlayerState
{
    public PlayerFallState(PlayerStateMachine stateMachine, string animationBoolName)
        : base(stateMachine, animationBoolName)
    {
    }

    protected override void OnPlayerStateUpdate()
    {
        this.PlayerController.SetLinearVelocityX(this.PlayerController.MoveSpeed * 0.8F * InputX);

        if (this.PlayerController.IsGroundDetected())
        {
            this.PlayerStateMachine?.ChangeState(this.PlayerStateMachine.IdleState);
        }
    }
}
