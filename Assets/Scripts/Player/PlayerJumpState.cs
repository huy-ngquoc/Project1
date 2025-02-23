#nullable enable

namespace Game;

public sealed class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player player, string animationBoolName)
        : base(player, animationBoolName) { }

    protected sealed override void OnEnter()
    {
        this.Player.SetLinearVelocityY(this.Player.JumpForce);
    }

    protected sealed override void OnUpdate()
    {
        var linearVelocityY = this.Player.GetLinearVelocityOrZeroY();
        if (linearVelocityY <= 0.0F)
        {
            this.StateMachine?.ChangeState(this.Player.FallState);
        }
    }

    protected sealed override void OnExit() { }
}
