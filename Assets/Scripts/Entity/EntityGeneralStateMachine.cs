#nullable enable

namespace Game;

using UnityEngine;

[DisallowMultipleComponent]
public abstract class EntityGeneralStateMachine : MonoBehaviour
{
    private IEntityState currentState = null!;
    private IEntityState? stateToChangeTo = null;

    public float StateMachineTimer { get; protected set; } = 0;

    public abstract EntityController EntityController { get; }

    public abstract IEntityState InitialState { get; }

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

    protected void Awake()
    {
        this.currentState = this.InitialState;
        this.currentState.Enter();
    }

    protected void Update()
    {
        var deltaTime = UnityEngine.Time.deltaTime;
        if (this.StateMachineTimer > deltaTime)
        {
            this.StateMachineTimer -= this.StateMachineTimer;
        }
        else
        {
            this.StateMachineTimer = 0;
        }

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
