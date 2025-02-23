#nullable enable

namespace Game;

public sealed class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }

    private PlayerState? stateToChangeTo = null;

    public PlayerStateMachine(PlayerState startState)
    {
        this.CurrentState = startState;
        this.CurrentState.Enter();
    }

    public void ChangeState(PlayerState? newState)
    {
        this.stateToChangeTo = newState;
    }

    public bool ChangeStateNotNull(PlayerState? newState)
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
