#nullable enable

namespace Game;

public sealed class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerStateMachine stateMachine, string animationBoolName)
        : base(stateMachine, animationBoolName)
    {
    }

    protected override void OnPlayerGroundedStateUpdate()
    {
        if (InputX != 0)
        {
            this.PlayerController.SetLinearVelocityX(InputX * this.PlayerController.MoveSpeed);
        }
        else
        {
            this.PlayerStateMachine?.ChangeState(this.PlayerStateMachine.IdleState);
        }
    }
}
