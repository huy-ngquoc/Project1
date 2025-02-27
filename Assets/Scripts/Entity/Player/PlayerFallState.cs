#nullable enable

namespace Game;

public sealed class PlayerFallState : PlayerState
{
    public PlayerFallState(PlayerStateMachine stateMachine, string animationBoolName)
        : base(stateMachine, animationBoolName)
    {
    }

    protected override void OnPlayerStateUpdate()
    {
        var playerController = this.PlayerController;
        if (playerController != null)
        {
            playerController.UnityAccess(p => p.SetLinearVelocityX(playerController.MoveSpeed * 0.8F * this.MoveInput.x));

            var playerStateMachine = this.PlayerStateMachine;
            if (playerController.IsGroundDetected() && (playerStateMachine != null))
            {
                playerStateMachine.SetStateToChangeTo(playerStateMachine.IdleState);
            }
        }
    }
}
