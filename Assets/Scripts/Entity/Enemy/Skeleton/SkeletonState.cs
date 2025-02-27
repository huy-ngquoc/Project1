#nullable enable

namespace Game;

public abstract class SkeletonState : EnemyState
{
    protected SkeletonState(SkeletonStateMachine skeletonStateMachine, string animationBoolName)
        : base(skeletonStateMachine, animationBoolName)
    {
        this.SkeletonStateMachine = skeletonStateMachine;
    }

    protected SkeletonStateMachine SkeletonStateMachine { get; }

    protected SkeletonController? SkeletonController => this.SkeletonStateMachine.SkeletonController;

    protected sealed override void OnEnemyStateEnter()
    {
        this.OnSkeletonStateEnter();
    }

    protected virtual void OnSkeletonStateEnter()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEnemyStateUpdate()
    {
        this.OnSkeletonStateUpdate();
    }

    protected virtual void OnSkeletonStateUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEnemyStateExit()
    {
        this.OnSkeletonStateExit();
    }

    protected virtual void OnSkeletonStateExit()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
