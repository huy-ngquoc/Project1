using UnityEngine;

namespace Game
{
    public sealed class PlayerDashSkillManager : PlayerSpecificSkillManager
    {
        [field: SerializeField]
        [field: ResolveComponent]
        private PlayerNormalDashSkill normalDashSkill = null!;

        [field: SerializeField]
        [field: ResolveComponent]
        private PlayerCloneDashSkill cloneDashSkill = null!;

        public enum DashType
        {
            Normal,
            Clone,
        }

        public PlayerDashSkill CurrentDashSkill
            => this.CurrentDashType switch
            {
                DashType.Normal => this.normalDashSkill,
                DashType.Clone => this.cloneDashSkill,
                _ => this.normalDashSkill,
            };

        [field: SerializeField]
        public DashType CurrentDashType { get; private set; } = DashType.Normal;

        public override bool IsUsable()
        {
            return this.CurrentDashSkill.IsUsable();
        }

        public override bool Cast()
        {
            return this.CurrentDashSkill.Cast();
        }

        protected override void OnPlayerSpecificSkillManagerAwake()
        {
            int currentSkill = PlayerPrefs.GetInt("Chosen_Skill", -1);

            if (currentSkill == this.normalDashSkill.skillId)
            {
                this.CurrentDashType = DashType.Normal;
                return;
            }

            if (currentSkill == this.cloneDashSkill.skillId)
            {
                this.CurrentDashType = DashType.Clone;
                return;
            }
        }
    }
}
