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
        var playerController = this.PlayerController;
        var moveInputX = this.MoveInput.x;
        if ((System.Math.Abs(moveInputX) > 0) && (playerController != null))
        {
            playerController.SetLinearVelocityX(moveInputX * playerController.MoveSpeed);
        }
        else
        {
            var playerStateMachine = this.PlayerStateMachine;
            playerStateMachine.UnityAccess(p => p.SetStateToChangeTo(p.IdleState));
        }
    }
}
