#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(PlayerController))]
    public sealed class PlayerStats : EntityStats
    {
        [field: SerializeReference]
        [field: ResolveComponent]
        public PlayerController PlayerController { get; private set; } = null!;

        public sealed override EntityController EntityController => this.PlayerController;

        protected override void OnEntityTakeDamage()
        {
            Debug.Log("Player is damaged!");
        }
    }
}