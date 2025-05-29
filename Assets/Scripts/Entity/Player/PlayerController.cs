#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(PlayerGeneralStateMachine), typeof(PlayerStats), typeof(PlayerInputHandler))]
    public sealed class PlayerController : EntityController
    {
        [field: Header("Player Jump info")]
        [field: SerializeField]
        [field: Range(5, 40)]
        public float JumpForce { get; private set; } = 15;

        [field: Header("Player State machine")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerGeneralStateMachine PlayerGeneralStateMachine { get; private set; } = null!;

        public override EntityGeneralStateMachine EntityGeneralStateMachine => this.PlayerGeneralStateMachine;

        [field: Header("Player Stats")]
        [field: SerializeField]
        [field: ResolveComponent]
        public PlayerStats PlayerStats { get; private set; } = null!;

        public override EntityStats EntityStats => this.PlayerStats;

        [field: Header("Player Input handler")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerInputHandler InputHandler { get; private set; } = null!;

        [field: Header("Player FX")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerFx PlayerFx { get; private set; } = null!;

        public override EntityFx EntityFx => this.PlayerFx;

        [field: Header("Player Skill manager")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerSkillManager PlayerSkillManager { get; private set; } = null!;

        public override EntitySkillManager EntitySkillManager => this.PlayerSkillManager;

        public override void Die()
        {
            this.PlayerGeneralStateMachine.SetStateToChangeTo(this.PlayerGeneralStateMachine.DeadState);
        }
    }
}
