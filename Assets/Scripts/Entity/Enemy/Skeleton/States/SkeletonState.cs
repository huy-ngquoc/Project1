#nullable enable

namespace Game;

public abstract class SkeletonState : EnemyState
{
    public abstract SkeletonGeneralStateMachine SkeletonGeneralStateMachine { get; }

    public sealed override EnemyGeneralStateMachine EnemyGeneralStateMachine => this.SkeletonGeneralStateMachine;

    public SkeletonController SkeletonController => this.SkeletonGeneralStateMachine.SkeletonController;

    public SkeletonSkillManager SkeletonSkillManager => this.SkeletonController.SkeletonSkillManager;

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
