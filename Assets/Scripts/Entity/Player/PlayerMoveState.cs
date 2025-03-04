#nullable enable

namespace Game;

public sealed class PlayerMoveState : PlayerGroundedState
{
    public PlayerMoveState(PlayerStateMachine playerStateMachine)
    {
        this.PlayerStateMachine = playerStateMachine;
    }

    public override string AnimationBoolName => AnimationBoolNameConstants.Move;

    protected override PlayerStateMachine PlayerStateMachine { get; }

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
