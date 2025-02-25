#nullable enable

namespace Game;

partial class Player
{
    private sealed class IdleState : GroundedState
    {
        public IdleState(Player player, string animationBoolName)
            : base(player, animationBoolName)
        {
        }

        protected override void OnGroundedEnter()
        {
            this.Player.SetLinearVelocityX(0);
        }

        protected override void OnGroundedUpdate()
        {
            if (InputX != 0)
            {
                this.StateMachine?.ChangeState(this.Player.moveState);
            }
        }
    }
}
