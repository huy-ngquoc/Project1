#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(PlayerGeneralStateMachine), typeof(PlayerInputHandler))]
    public sealed class PlayerController : EntityController
    {
        [field: Header("Jump info")]
        [field: SerializeField]
        [field: Range(5, 40)]
        public float JumpForce { get; private set; } = 15;

        [field: Header("State machine")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerGeneralStateMachine PlayerGeneralStateMachine { get; private set; } = null!;

        public override EntityGeneralStateMachine EntityGeneralStateMachine => this.PlayerGeneralStateMachine;

        [field: Header("Input handler")]
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerInputHandler InputHandler { get; private set; } = null!;
    }
}
