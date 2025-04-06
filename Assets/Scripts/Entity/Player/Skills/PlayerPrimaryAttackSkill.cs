#nullable enable

namespace Game
{
    public sealed class PlayerPrimaryAttackSkill : PlayerSkill
    {
        protected override void CastLogic()
        {
            var playerGeneralStateMachine = this.PlayerGeneralStateMachine;
            playerGeneralStateMachine.SetStateToChangeTo(playerGeneralStateMachine.PrimaryAttackState);
        }
    }
}
