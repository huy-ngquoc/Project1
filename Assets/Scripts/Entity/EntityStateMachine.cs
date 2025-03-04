#nullable enable

namespace Game;

using UnityEngine;

[DisallowMultipleComponent]
public abstract class EntityStateMachine : MonoBehaviour
{
    private EntityState? currentState = null;
    private EntityState? stateToChangeTo = null;

    public abstract EntityController? EntityController { get; }

    public void SetStateToChangeTo(EntityState newState)
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

    protected void Awake()
    {
        QuickLog.AssertIfUnityObjectNull(this, this.EntityController);
    }

    protected void Start()
    {
        Debug.Assert(
            this.stateToChangeTo != null,
            $"Game Object `{this.gameObject.name}` doesn't have a state to switch from null on `Start()` function! " +
            "Ensure that the sealed class has switched the current state to a state before the `Start()` function is called!");

        this.currentState = this.stateToChangeTo;
        this.stateToChangeTo = null;
        this.currentState?.Enter();
    }

    protected void Update()
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
}
