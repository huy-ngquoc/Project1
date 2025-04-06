#nullable enable

namespace Game;

public sealed class PlayerPrimaryAttack1State : PlayerPrimaryAttackState
{
    public PlayerPrimaryAttack1State(PlayerPrimaryAttackStateMachine playerPrimaryAttackStateMachine)
    {
        this.PlayerPrimaryAttackStateMachine = playerPrimaryAttackStateMachine;
    }

    public override string AnimationBoolName => AnimationNameConstants.Bool.PrimaryAttack1;

    public override PlayerPrimaryAttackStateMachine PlayerPrimaryAttackStateMachine { get; }
}
