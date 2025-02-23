#nullable enable

namespace Game;
public sealed class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player player, string animationBoolName)
        : base(player, animationBoolName) { }

    protected sealed override void OnGroundedEnter()
    {
        this.Player.SetZeroLinearVelocity();
    }

    protected sealed override void OnGroundedUpdate()
    {
        if ((this.StateMachine != null) && (!this.StateMachine.HasStateToChangeTo()) && (InputX != 0))
        {
            this.StateMachine.ChangeState(this.Player.MoveState);
        }
    }

    protected sealed override void OnGroundedExit() { }
}
