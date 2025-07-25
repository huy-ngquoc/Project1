#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerCrystalSkillManager : PlayerSpecificSkillManager
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        private PlayerNormalCrystalSkill normalCrystalSkill = null!;

        [field: SerializeReference]
        [field: ResolveComponent]
        private PlayerSwappingCrystalSkill swappingCrystalSkill = null!;

        [field: SerializeReference]
        [field: ResolveComponent]
        private PlayerMultiCrystalSkill multiCrystalSkill = null!;

        public enum CrystalType
        {
            Normal,
            Swapping,
            Multi,
        }

        [field: SerializeField]
        public CrystalType CurrentCrystalType { get; private set; } = CrystalType.Normal;

        private PlayerCrystalSkill CurrentCrystalSkill => this.CurrentCrystalType switch
        {
            CrystalType.Normal => this.normalCrystalSkill,
            CrystalType.Swapping => this.swappingCrystalSkill,
            CrystalType.Multi => this.multiCrystalSkill,
            _ => this.normalCrystalSkill,
        };

        public override bool Cast()
        {
            if (this.CurrentCrystalSkill.IsUsable())
            {
                this.CurrentCrystalSkill.Cast();
                return true;
            }
            return false;
        }

        public override bool IsUsable()
        {
            return this.CurrentCrystalSkill.IsUsable();
        }

        protected override void OnPlayerSpecificSkillManagerAwake()
        {
            int currentSkill = PlayerPrefs.GetInt("Chosen_Skill", -1);
            if (currentSkill == this.normalCrystalSkill.skillId)
            {
                this.CurrentCrystalType = CrystalType.Normal;
                return;
            }
            if (currentSkill == this.swappingCrystalSkill.skillId)
            {
                this.CurrentCrystalType = CrystalType.Swapping;
                return;
            }
            if (currentSkill == this.multiCrystalSkill.skillId)
            {
                this.CurrentCrystalType = CrystalType.Multi;
                return;
            }
        }
    }
}
