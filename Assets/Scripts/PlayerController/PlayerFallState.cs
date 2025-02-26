#nullable enable

namespace Game;

partial class PlayerController
{
    partial class PlayerStateMachine
    {
        private sealed class PlayerFallState : PlayerState
        {
            public PlayerFallState(PlayerStateMachine stateMachine, string animationBoolName)
                : base(stateMachine, animationBoolName)
            {
            }

            protected override void OnUpdate()
            {
                this.Player.SetLinearVelocityX(this.Player.MoveSpeed * 0.8F * InputX);

                if (this.Player.IsGroundDetected())
                {
                    this.StateMachine?.ChangeState(this.StateMachine.idleState);
                }
            }
        }
    }
}
