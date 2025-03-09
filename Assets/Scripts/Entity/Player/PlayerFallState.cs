#nullable enable

namespace Game;

public sealed class PlayerFallState : PlayerState
{
    public PlayerFallState(PlayerStateMachine playerStateMachine)
    {
        this.PlayerStateMachine = playerStateMachine;
    }

    public override string AnimationBoolName => AnimationBoolNameConstants.Fall;

    protected override PlayerStateMachine PlayerStateMachine { get; }

    protected override void OnPlayerStateUpdate()
    {
        var playerStateMachine = this.PlayerStateMachine;

        var playerController = this.PlayerController;
        if (playerController == null)
        {
            playerStateMachine.SetStateToChangeTo(playerStateMachine.IdleState);
        }
        else if (playerController.IsGroundDetected)
        {
            playerStateMachine.SetStateToChangeTo(playerStateMachine.IdleState);
        }
        else
        {
            playerController.UnityAccess(p => p.SetLinearVelocityX(playerController.MoveSpeed * 0.8F * this.MoveInputInt.x));
        }
    }
}
