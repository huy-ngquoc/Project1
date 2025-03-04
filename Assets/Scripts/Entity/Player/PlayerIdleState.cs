#nullable enable

namespace Game;

public sealed class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerStateMachine playerStateMachine)
    {
        this.PlayerStateMachine = playerStateMachine;
    }

    public override string AnimationBoolName => AnimationBoolNameConstants.Idle;

    protected override PlayerStateMachine PlayerStateMachine { get; }

    protected override void OnPlayerGroundedStateEnter()
    {
        this.PlayerController.UnityAccess(p => p.SetZeroLinearVelocityX());
    }

    protected override void OnPlayerGroundedStateUpdate()
    {
        var playerStateMachine = this.PlayerStateMachine;
        if ((System.Math.Abs(this.MoveInput.x) > 0) && (playerStateMachine != null))
        {
            playerStateMachine.SetStateToChangeTo(playerStateMachine.MoveState);
        }
    }
}
