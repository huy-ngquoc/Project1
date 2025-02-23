#nullable enable

namespace Game
{
    using UnityEngine;

    public sealed class Player : Entity
    {
        [field: Header("Move info")]
        [field: SerializeField, Range(1.0F, 30.0F)] public float MoveSpeed { get; private set; } = 8.0F;
        [field: SerializeField][field: Range(1.0F, 40.0F)] public float JumpForce { get; private set; } = 12.0F;

        public PlayerStateMachine? StateMachine { get; private set; } = null;

        public PlayerIdleState? IdleState { get; private set; } = null;

        public PlayerMoveState? MoveState { get; private set; } = null;

        public PlayerJumpState? JumpState { get; private set; } = null;
        public PlayerFallState? FallState { get; private set; } = null;

        protected override void OnAwake()
        {
            this.IdleState = new PlayerIdleState(this, "Idle");
            this.MoveState = new PlayerMoveState(this, "Move");
            this.JumpState = new PlayerJumpState(this, "Jump");
            this.FallState = new PlayerFallState(this, "Jump");

            this.StateMachine = new PlayerStateMachine(this.IdleState);
        }

        protected override void OnUpdate()
        {
            this.StateMachine?.UpdateState();
        }
    }
}
