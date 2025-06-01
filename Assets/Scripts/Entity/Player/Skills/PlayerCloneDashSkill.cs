#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerCloneDashSkill : PlayerDashSkill
    {        
        protected override void CastLogic()
        {
            var playerGeneralStateMachine = this.PlayerGeneralStateMachine;
            playerGeneralStateMachine.SetStateToChangeTo(playerGeneralStateMachine.DashState);
            this.PlayerSkillManager.CloneSkill.CreateClone(this.PlayerController.transform.position); 
        }
    }
}
