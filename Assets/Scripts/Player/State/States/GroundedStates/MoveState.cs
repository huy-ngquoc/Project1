#nullable enable

namespace Game;

partial class Player
{
    private sealed class MoveState : GroundedState
    {
        public MoveState(Player player, string animationBoolName)
            : base(player, animationBoolName)
        {
        }

        protected override void OnGroundedUpdate()
        {
            if (InputX == 0)
            {
                this.StateMachine?.ChangeState(this.Player.idleState);
            }
            else
            {
                this.Player.SetLinearVelocityX(InputX * this.Player.MoveSpeed);
            }
        }
    }
}
