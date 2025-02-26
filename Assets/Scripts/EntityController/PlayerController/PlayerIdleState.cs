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

            protected override void OnPlayerGroundedStateEnter()
            {
                this.PlayerController.SetZeroLinearVelocityX();
            }

            protected override void OnPlayerGroundedStateUpdate()
            {
                if (InputX != 0)
                {
                    this.PlayerStateMachine?.ChangeState(this.PlayerStateMachine.moveState);
                }
            }
        }
    }
}
