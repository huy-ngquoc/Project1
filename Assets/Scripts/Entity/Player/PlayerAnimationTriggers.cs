#nullable enable

namespace Game
{
    using UnityEngine;
    using MonoBehaviour = UnityEngine.MonoBehaviour;
    using SerializeField = UnityEngine.SerializeField;

    public sealed class PlayerAnimationTriggers : MonoBehaviour
    {
        [field: Header("Controller")]
        [field: SerializeField]
        [field: ResolveComponentInParent("Player")]
        public PlayerController PlayerController { get; private set; } = null!;

        private void AnimationFinishTrigger() => this.PlayerController.AnimationFinishTrigger();
    }
}
