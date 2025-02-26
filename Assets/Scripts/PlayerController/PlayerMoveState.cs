#nullable enable

namespace Game;

partial class PlayerController
{
    partial class PlayerStateMachine
    {
        private sealed class PlayerMoveState : PlayerGroundedState
        {
            public PlayerMoveState(PlayerStateMachine stateMachine, string animationBoolName)
                : base(stateMachine, animationBoolName)
            {
            }

            protected override void OnGroundedUpdate()
            {
                if (InputX != 0)
                {
                    this.Player.SetLinearVelocityX(InputX * this.Player.MoveSpeed);
                }
                else
                {
                    this.StateMachine?.ChangeState(this.StateMachine.idleState);
                }
            }
        }
    }
}
