#nullable enable

namespace Game;

public abstract class EntitySpecificStateMachine : IEntityStateMachine
{
    private IEntityState currentState = null!;
    private IEntityState? stateToChangeTo = null;

    public float StateMachineTimer { get; protected set; } = 0;

    public bool TriggerCalled { get; protected set; } = false;

    public abstract EntityGeneralStateMachine EntityGeneralStateMachine { get; }

    public EntityController EntityController => this.EntityGeneralStateMachine.EntityController;

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

    public void AnimationFinishTrigger() => this.TriggerCalled = true;

    public void Enter()
    {
        this.currentState = this.InitialState;
        this.TriggerCalled = false;
        this.currentState.Enter();
    }

    public void Update()
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
            this.TriggerCalled = false;
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
