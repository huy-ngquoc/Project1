#nullable enable

namespace Game;

public sealed class PlayerPrimaryAttack3State : PlayerPrimaryAttackState
{
    public PlayerPrimaryAttack3State(PlayerPrimaryAttackStateMachine playerPrimaryAttackStateMachine)
    {
        this.PlayerPrimaryAttackStateMachine = playerPrimaryAttackStateMachine;
    }

    public override string AnimationBoolName => AnimationNameConstants.Bool.PrimaryAttack3;

    public override PlayerPrimaryAttackStateMachine PlayerPrimaryAttackStateMachine { get; }
}
