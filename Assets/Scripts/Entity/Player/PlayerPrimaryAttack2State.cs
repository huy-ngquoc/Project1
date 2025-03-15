#nullable enable

namespace Game;

public sealed class PlayerPrimaryAttack2State : PlayerPrimaryAttackState
{
    public PlayerPrimaryAttack2State(PlayerPrimaryAttackStateMachine playerPrimaryAttackStateMachine)
    {
        this.PlayerPrimaryAttackStateMachine = playerPrimaryAttackStateMachine;
    }

    public override string AnimationBoolName => AnimationNameConstants.Bool.PrimaryAttack2;

    public override PlayerPrimaryAttackStateMachine PlayerPrimaryAttackStateMachine { get; }
}
