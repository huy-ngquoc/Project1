#nullable enable

namespace Game;

public sealed class PlayerFallState : PlayerState
{
    public PlayerFallState(Player player, string animationBoolName)
        : base(player, animationBoolName) { }

    protected sealed override void OnUpdate()
    {
        this.Player.SetLinearVelocityX(this.Player.MoveSpeed * 0.8F * InputX);

        if (this.Player.IsGroundDetected())
        {
            this.StateMachine?.ChangeState(this.Player.IdleState);
        }
    }

    protected sealed override void OnEnter() { }

    protected sealed override void OnExit() { }
}
