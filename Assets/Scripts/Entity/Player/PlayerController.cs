#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(PlayerInputHandler), typeof(PlayerStateMachine))]
    public sealed class PlayerController : EntityController
    {
        [field: Header("Jump info")]
        [field: SerializeField]
        [field: Range(5, 40)]
        public float JumpForce { get; private set; } = 15;

        [field: Header("Input handler")]
        [field: SerializeReference]
        [field: ResolveComponentInChildren]
        public PlayerInputHandler? InputHandler { get; private set; }
    }
}
