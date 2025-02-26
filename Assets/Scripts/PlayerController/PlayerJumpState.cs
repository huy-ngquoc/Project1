#nullable enable

namespace Game;

partial class PlayerController
{
    partial class PlayerStateMachine
    {
        private sealed class PlayerJumpState : PlayerState
        {
            public PlayerJumpState(PlayerStateMachine stateMachine, string animationBoolName)
                : base(stateMachine, animationBoolName)
            {
            }

            protected override void OnEnter()
            {
                this.Player.SetLinearVelocityY(this.Player.JumpForce);
            }

            protected override void OnUpdate()
            {
                var linearVelocityY = this.Player.GetLinearVelocityOrZeroY();
                if (linearVelocityY <= 0)
                {
                    this.StateMachine?.ChangeState(this.StateMachine.fallState);
                }
            }
        }
    }
}
