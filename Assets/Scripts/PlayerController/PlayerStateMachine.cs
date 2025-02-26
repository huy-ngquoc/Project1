#nullable enable

namespace Game;

partial class PlayerController
{
    private sealed partial class PlayerStateMachine
    {
        private readonly PlayerController player;
        private readonly PlayerIdleState idleState;
        private readonly PlayerMoveState moveState;
        private readonly PlayerJumpState jumpState;
        private readonly PlayerFallState fallState;

        private PlayerState currentState;
        private PlayerState? stateToChangeTo = null;

        public PlayerStateMachine(PlayerController player)
        {
            this.player = player;

            this.idleState = new PlayerIdleState(this, "Idle");
            this.moveState = new PlayerMoveState(this, "Move");
            this.jumpState = new PlayerJumpState(this, "Jump");
            this.fallState = new PlayerFallState(this, "Jump");

            this.currentState = this.idleState;
            this.currentState.Enter();
        }

        public void UpdateState()
        {
            this.currentState.Update();

            while (this.stateToChangeTo != null)
            {
                this.currentState.Exit();
                this.currentState = this.stateToChangeTo;
                this.stateToChangeTo = null;
                this.currentState.Enter();
                this.currentState.Update();
            }
        }

        private void ChangeState(PlayerState newState)
        {
            this.stateToChangeTo = newState;
        }

        private bool HasStateToChangeTo()
        {
            return this.stateToChangeTo != null;
        }

        private void CancelChangingState()
        {
            this.stateToChangeTo = null;
        }
    }
}
