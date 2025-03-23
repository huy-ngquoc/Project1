#nullable enable

namespace Game;
public abstract class SkeletonBattleState : SkeletonState
{
    public abstract SkeletonBattleStateMachine SkeletonBattleStateMachine { get; }

    public sealed override SkeletonGeneralStateMachine SkeletonGeneralStateMachine
        => this.SkeletonBattleStateMachine.SkeletonGeneralStateMachine;

    protected sealed override void OnSkeletonStateEnter()
    {
        this.OnSkeletonBattleStateEnter();
    }

    protected virtual void OnSkeletonBattleStateEnter()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnSkeletonStateUpdate()
    {
        this.OnSkeletonBattleStateUpdate();
    }

    protected virtual void OnSkeletonBattleStateUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnSkeletonStateExit()
    {
        this.OnSkeletonBattleStateExit();
    }

    protected virtual void OnSkeletonBattleStateExit()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
