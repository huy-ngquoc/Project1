#nullable enable

namespace Game;

public abstract partial class EntityStateMachine
{
    private EntityState? currentState = null;
    private EntityState? stateToChangeTo = null;

    protected EntityStateMachine(EntityController entityController)
    {
        this.EntityController = entityController;
    }

    public EntityController EntityController { get; }

    public void UpdateState()
    {
        this.currentState?.Update();

        while (this.stateToChangeTo != null)
        {
            this.currentState?.Exit();
            this.currentState = this.stateToChangeTo;
            this.stateToChangeTo = null;
            this.currentState.Enter();

            // TODO: should we update state right after changing?
            // this.currentState.Update();
        }
    }

    public void ChangeState(EntityState newState)
    {
        this.stateToChangeTo = newState;
    }

    public bool HasStateToChangeTo()
    {
        return this.stateToChangeTo != null;
    }

    public void CancelChangingState()
    {
        this.stateToChangeTo = null;
    }

    public void AnimationFinishTrigger() => this.currentState?.AnimationFinishTrigger();
}
