#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(PlayerStateMachine), typeof(PlayerInputHandler))]
    public sealed class PlayerController : EntityController
    {
        [field: Header("Jump info")]
        [field: SerializeField]
        [field: Range(5, 40)]
        public float JumpForce { get; private set; } = 15;

        [field: Header("State machine")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerStateMachine PlayerStateMachine { get; private set; } = null!;

        public override EntityStateMachine EntityStateMachine => this.PlayerStateMachine;

        [field: Header("Input handler")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerInputHandler InputHandler { get; private set; } = null!;
    }
}
