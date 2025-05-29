#nullable enable

namespace Game;

public sealed class PlayerDeadState : PlayerState
{
    public PlayerDeadState(PlayerGeneralStateMachine playerGeneralStateMachine)
    {
        this.PlayerGeneralStateMachine = playerGeneralStateMachine;
    }

    public override PlayerGeneralStateMachine PlayerGeneralStateMachine { get; }

    public override string AnimationBoolName { get; } = AnimationNameConstants.Bool.Dead;

    protected override void OnPlayerStateUpdate()
    {
        this.PlayerController.SetZeroLinearVelocity();
    }
}
