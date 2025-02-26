#nullable enable

namespace Game;

public sealed class PlayerIdleState : PlayerGroundedState
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
            this.PlayerStateMachine?.ChangeState(this.PlayerStateMachine.MoveState);
        }
    }
}
