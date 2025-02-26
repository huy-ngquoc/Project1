#nullable enable

namespace Game;

partial class PlayerController
{
    private sealed partial class PlayerStateMachine : EntityStateMachine
    {
        private readonly PlayerController playerController;
        private readonly PlayerIdleState idleState;
        private readonly PlayerMoveState moveState;
        private readonly PlayerJumpState jumpState;
        private readonly PlayerFallState fallState;

        public PlayerStateMachine(PlayerController playerController)
            : base(playerController)
        {
            this.playerController = playerController;

            this.idleState = new PlayerIdleState(this, "Idle");
            this.moveState = new PlayerMoveState(this, "Move");
            this.jumpState = new PlayerJumpState(this, "Jump");
            this.fallState = new PlayerFallState(this, "Jump");

            this.ChangeState(this.idleState);
        }
    }
}
