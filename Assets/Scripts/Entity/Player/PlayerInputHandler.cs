#nullable enable

namespace Game
{
    using UnityEngine;

    [DisallowMultipleComponent]
    public sealed class PlayerInputHandler : MonoBehaviour, System.IDisposable
    {
        private InputSystemAction? inputSystemAction = null;

        public Vector2 MoveInput { get; private set; } = Vector2.zero;

        public bool JumpPressed { get; private set; } = false;

        public void CancelJumpInputAction() => this.JumpPressed = false;

        public void Dispose()
        {
            this.inputSystemAction?.Dispose();
        }

        private void Awake()
        {
            this.inputSystemAction = new InputSystemAction();
            var playerActions = this.inputSystemAction.Player;

            playerActions.Move.performed += context => this.MoveInput = context.ReadValue<Vector2>();
            playerActions.Move.canceled += context => this.MoveInput = Vector2.zero;

            playerActions.Jump.performed += context => this.JumpPressed = true;
            playerActions.Jump.canceled += context => this.JumpPressed = false;

            this.inputSystemAction.Enable();
        }

        private void OnEnable()
        {
            this.inputSystemAction?.Enable();
        }

        private void OnDisable()
        {
            this.inputSystemAction?.Disable();
        }

        private void OnDestroy()
        {
            this.inputSystemAction?.Disable();
        }
    }
}
