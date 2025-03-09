#nullable enable

namespace Game;

using UnityEngine;

public abstract class EntityStateMachine : MonoBehaviour
{
    private EntityState currentState = null!;
    private EntityState? stateToChangeTo = null;

    public abstract EntityController EntityController { get; }

    public abstract EntityState InitialState { get; }

    public bool HasStateToChangeTo()
    {
        return this.stateToChangeTo != null;
    }

    public void SetStateToChangeTo(EntityState newState)
    {
        this.stateToChangeTo = newState;
    }

    public void CancelChangingState()
    {
        this.stateToChangeTo = null;
    }

    public void AnimationFinishTrigger() => this.currentState?.AnimationFinishTrigger();

    protected void Awake()
    {
        this.currentState = this.InitialState;
        this.currentState.Enter();
    }

    protected void Update()
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
}
