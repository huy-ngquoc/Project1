#nullable enable

namespace Game;

using UnityEngine;

public abstract class EntityState
{
    public abstract string AnimationBoolName { get; }

    public float StateTimer { get; protected set; } = 0;

    public bool TriggerCalled { get; protected set; } = false;

    public abstract EntityStateMachine EntityStateMachine { get; }

    public EntityController EntityController => this.EntityStateMachine.EntityController;

    public void Enter()
    {
        this.TriggerCalled = false;

        var animator = this.EntityController.Animator;
        var animationBoolName = this.AnimationBoolName;
        if (!string.IsNullOrWhiteSpace(animationBoolName))
        {
            animator.SetBool(animationBoolName, true);
        }

        this.OnEntityStateEnter();
    }

    public void Update()
    {
        if (this.StateTimer > Time.deltaTime)
        {
            this.StateTimer -= Time.deltaTime;
        }
        else
        {
            this.StateTimer = 0;
        }

        this.OnEntityStateUpdate();
    }

    public void Exit()
    {
        var animator = this.EntityController.Animator;
        var animationBoolName = this.AnimationBoolName;
        if (!string.IsNullOrWhiteSpace(animationBoolName))
        {
            animator.SetBool(animationBoolName, false);
        }

        this.OnEntityStateExit();
    }

    public void AnimationFinishTrigger() => this.TriggerCalled = true;

    protected virtual void OnEntityStateEnter()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected virtual void OnEntityStateUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected virtual void OnEntityStateExit()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
