#nullable enable

namespace Game;

partial class PlayerController
{
    partial class PlayerStateMachine
    {
        private sealed class PlayerIdleState : PlayerGroundedState
        {
            public PlayerIdleState(PlayerStateMachine stateMachine, string animationBoolName)
                : base(stateMachine, animationBoolName)
            {
            }

            protected override void OnGroundedEnter()
            {
                this.Player.SetZeroLinearVelocityX();
            }

            protected override void OnGroundedUpdate()
            {
                if (InputX != 0)
                {
                    this.StateMachine?.ChangeState(this.StateMachine.moveState);
                }
            }
        }
    }
}
