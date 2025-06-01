#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerNormalDashSkill : PlayerDashSkill
    {        
        protected override void CastLogic()
        {
            var playerGeneralStateMachine = this.PlayerGeneralStateMachine;
            playerGeneralStateMachine.SetStateToChangeTo(playerGeneralStateMachine.DashState);
        }
    }
}
