#nullable enable

namespace Game
{
    using UnityEngine;

    [RequireComponent(typeof(PlayerController))]
    public sealed class PlayerStateMachine : EntityStateMachine
    {
        public PlayerStateMachine()
        {
            this.IdleState = new PlayerIdleState(this, "Idle");
            this.MoveState = new PlayerMoveState(this, "Move");
            this.JumpState = new PlayerJumpState(this, "Jump");
            this.FallState = new PlayerFallState(this, "Jump");

            this.SetStateToChangeTo(this.IdleState);
        }

        public PlayerController? PlayerController { get; private set; }

        public PlayerIdleState IdleState { get; }

        public PlayerMoveState MoveState { get; }

        public PlayerJumpState JumpState { get; }

        public PlayerFallState FallState { get; }

        protected override void OnEntityStateMachineValidate()
        {
            this.PlayerController = (PlayerController?)this.EntityController;
        }
    }
}
