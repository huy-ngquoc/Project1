#nullable enable

namespace Game;

partial class Player
{
    private sealed class StateMachine
    {
        private State? stateToChangeTo = null;

        public StateMachine(State startState)
        {
            this.CurrentState = startState;
            this.CurrentState.Enter();
        }

        public State CurrentState { get; private set; }

        public void ChangeState(State? newState)
        {
            this.stateToChangeTo = newState;
        }

        public bool ChangeStateNotNull(State? newState)
        {
            if (newState == null)
            {
                return false;
            }

            this.stateToChangeTo = newState;
            return true;
        }

        public void CancelChangingState()
        {
            this.stateToChangeTo = null;
        }

        public void UpdateState()
        {
            this.CurrentState.Update();

            while (this.stateToChangeTo != null)
            {
                this.CurrentState.Exit();
                this.CurrentState = this.stateToChangeTo;
                this.stateToChangeTo = null;
                this.CurrentState.Enter();
            }
        }

        public bool HasStateToChangeTo()
        {
            return this.stateToChangeTo != null;
        }
    }
}
