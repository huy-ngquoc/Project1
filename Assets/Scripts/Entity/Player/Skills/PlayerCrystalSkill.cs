#nullable enable

namespace Game
{
    using UnityEngine;

    public abstract class PlayerCrystalSkill : PlayerSkill
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        private PlayerSkillManager playerSkillManager = null!;

        [field: SerializeField]
        protected GameObject CrystalPrefab { get; private set; } = null!;

        [field: SerializeField]
        [field: Range(0.5F, 5)]
        public float CrystalDuration { get; private set; } = 1.5F;

        public override PlayerSkillManager PlayerSkillManager => this.playerSkillManager;
    }
}
