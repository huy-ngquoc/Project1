#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class PlayerAnimationTriggers : EntityAnimationTriggers
    {
        [field: Header("Player controller")]
        [field: SerializeField]
        [field: ResolveComponentInParent("Player")]
        public PlayerController PlayerController { get; private set; } = null!;

        public override EntityController EntityController => this.PlayerController;
    }
}