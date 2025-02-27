#nullable enable

namespace Game
{

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

        public PlayerController? PlayerController => this.EntityController as PlayerController;

        public PlayerIdleState IdleState { get; }

        public PlayerMoveState MoveState { get; }

        public PlayerJumpState JumpState { get; }

        public PlayerFallState FallState { get; }
    }
}
