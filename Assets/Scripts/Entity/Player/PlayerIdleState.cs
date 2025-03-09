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
        var moveInputIntX = this.MoveInputXInt;

        if (!this.IsGroundDetected)
        {
            playerStateMachine.SetStateToChangeTo(playerStateMachine.FallState);
        }
        else if ((moveInputIntX != 0) && ((moveInputIntX != this.FacingDirection) || (!this.IsWallDetected)))
        {
            playerStateMachine.SetStateToChangeTo(playerStateMachine.MoveState);
        }
        else
        {
            // State stay remain...
        }
    }
}
