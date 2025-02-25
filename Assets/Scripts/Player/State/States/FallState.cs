#nullable enable

namespace Game;

partial class Player
{
    private sealed class FallState : State
    {
        public FallState(Player player, string animationBoolName)
            : base(player, animationBoolName)
        {
        }

        protected override void OnUpdate()
        {
            this.Player.SetLinearVelocityX(this.Player.MoveSpeed * 0.8F * InputX);

            if (this.Player.IsGroundDetected())
            {
                this.StateMachine?.ChangeState(this.Player.idleState);
            }
        }
    }
}
