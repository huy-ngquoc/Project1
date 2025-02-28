#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(PlayerInputHandler), typeof(PlayerStateMachine))]
    public sealed class PlayerController : EntityController
    {
        [field: Header("Move info")]

        [field: SerializeField]
        [field: Range(1, 30)]
        public float MoveSpeed { get; private set; } = 8;

        [field: SerializeField]
        [field: Range(1, 40)]
        public float JumpForce { get; private set; } = 12;

        [field: Header("Input handler")]

        [field: SerializeReference]
        [field: ResolveComponentInChildren]
        public PlayerInputHandler? InputHandler { get; private set; }
    }
}
