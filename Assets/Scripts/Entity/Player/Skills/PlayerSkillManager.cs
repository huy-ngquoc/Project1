#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(PlayerController))]
    public sealed class PlayerSkillManager : EntitySkillManager
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerController PlayerController { get; private set; } = null!;

        public override EntityController EntityController => this.PlayerController;

        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerPrimaryAttackSkill PrimaryAttackSkill { get; private set; } = null!;

        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerDashSkill DashSkill { get; private set; } = null!;
    }
}
