#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(PlayerController))]
    public sealed class PlayerStateMachine : EntityStateMachine
    {
        public PlayerStateMachine()
        {
            this.IdleState = new PlayerIdleState(this);
            this.MoveState = new PlayerMoveState(this);
            this.JumpState = new PlayerJumpState(this);
            this.FallState = new PlayerFallState(this);

            this.SetStateToChangeTo(this.IdleState);
        }

        [field: Header("Controller")]
        [field: SerializeReference]
        [field: ResolveComponentInChildren]
        public PlayerController? PlayerController { get; private set; } = null;

        public PlayerIdleState IdleState { get; }

        public PlayerMoveState MoveState { get; }

        public PlayerJumpState JumpState { get; }

        public PlayerFallState FallState { get; }

        public sealed override EntityController? EntityController => this.PlayerController;
    }
}
