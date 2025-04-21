#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerDashSkill : PlayerSkill
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        private PlayerSkillManager playerSkillManager = null!;

        public override PlayerSkillManager PlayerSkillManager => this.playerSkillManager;

        [field: SerializeField]
        [field: Range(5, 200)]
        public float DashSpeed { get; private set; } = 25;

        [field: SerializeField]
        [field: Range(0.01F, 1)]
        public float DashDuration { get; private set; } = 0.2F;

        protected override void CastLogic()
        {
            var playerGeneralStateMachine = this.PlayerGeneralStateMachine;
            playerGeneralStateMachine.SetStateToChangeTo(playerGeneralStateMachine.DashState);
            this.PlayerSkillManager.CloneSkill.CreateClone(this.PlayerController.transform.position);
        }
    }
}
