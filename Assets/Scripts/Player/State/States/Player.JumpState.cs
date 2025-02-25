#nullable enable

namespace Game;

partial class Player
{
    private sealed class JumpState : State
    {
        public JumpState(Player player, string animationBoolName)
            : base(player, animationBoolName)
        {
        }

        protected override void OnEnter()
        {
            this.Player.SetLinearVelocityY(this.Player.JumpForce);
        }

        protected override void OnUpdate()
        {
            var linearVelocityY = this.Player.GetLinearVelocityOrZeroY();
            if (linearVelocityY <= 0.0F)
            {
                this.StateMachine?.ChangeState(this.Player.fallState);
            }
        }
    }
}
