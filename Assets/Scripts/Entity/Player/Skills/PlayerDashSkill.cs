#nullable enable

namespace Game
{
    using UnityEngine;

    public abstract class PlayerDashSkill : PlayerSkill
    {        
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerDashSkillManager DaskSkillManager { get; private set; } =null!;

        public sealed override PlayerSkillManager PlayerSkillManager => this.DaskSkillManager.PlayerSkillManager;

        [field: SerializeField]
        [field: Range(5, 200)]
        public float DashSpeed { get; private set; } = 25;

        [field: SerializeField]
        [field: Range(0.01F, 1)]
        public float DashDuration { get; private set; } = 0.2F;
    }
}
