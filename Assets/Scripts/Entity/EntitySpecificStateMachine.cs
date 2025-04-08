#nullable enable

namespace Game;

public abstract class EntitySpecificStateMachine : IEntityState
{
    private IEntityState currentState = null!;
    private IEntityState? stateToChangeTo = null;

    public abstract EntityGeneralStateMachine EntityGeneralStateMachine { get; }

    public EntityController EntityController => this.EntityGeneralStateMachine.EntityController;

    protected abstract IEntityState InitialState { get; }

    public bool HasStateToChangeTo()
    {
        return this.stateToChangeTo != null;
    }

    public void SetStateToChangeTo(IEntityState newState)
    {
        this.stateToChangeTo = newState;
    }

    public void CancelChangingState()
    {
        this.stateToChangeTo = null;
    }

    public void AnimationFinishTrigger() => this.currentState.AnimationFinishTrigger();

    public void Enter()
    {
        this.currentState = this.InitialState;
        this.currentState.Enter();
    }

    public void Update()
    {
        this.currentState.Update();

        while (this.stateToChangeTo != null)
        {
            this.currentState.Exit();
            this.currentState = this.stateToChangeTo;
            this.stateToChangeTo = null;
            this.currentState.Enter();

            // TODO: should we update state right after changing?
            // this.currentState.Update();
        }
    }

    public void Exit()
    {
        this.currentState.Exit();
    }
}
