#nullable enable

namespace Game;

public abstract class SkeletonGroundedState : SkeletonState
{
    public abstract SkeletonGroundedStateMachine SkeletonGroundedStateMachine { get; }

    public sealed override SkeletonGeneralStateMachine SkeletonGeneralStateMachine => this.SkeletonGroundedStateMachine.SkeletonGeneralStateMachine;

    protected sealed override void OnSkeletonStateEnter()
    {
        this.OnSkeletonGroundedStateEnter();
    }

    protected virtual void OnSkeletonGroundedStateEnter()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnSkeletonStateUpdate()
    {
        this.OnSkeletonGroundedStateUpdate();
    }

    protected virtual void OnSkeletonGroundedStateUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnSkeletonStateExit()
    {
        this.OnSkeletonGroundedStateExit();
    }

    protected virtual void OnSkeletonGroundedStateExit()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
