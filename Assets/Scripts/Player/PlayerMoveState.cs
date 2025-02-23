#nullable enable

namespace Game;

public sealed class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(Player player, string animationBoolName)
        : base(player, animationBoolName) { }

    protected sealed override void OnGroundedEnter() { }

    protected sealed override void OnGroundedUpdate()
    {
        if ((this.StateMachine != null) && (!this.StateMachine.HasStateToChangeTo()))
        {
            if (InputX == 0)
            {
                this.StateMachine.ChangeState(this.Player.IdleState);
            }
            else
            {
                this.Player.SetLinearVelocityX(InputX * this.Player.MoveSpeed);
            }
        }
    }

    protected sealed override void OnGroundedExit() { }
}
