#nullable enable

namespace Game;

public abstract class EnemyState : EntityState
{
    public abstract EnemyGeneralStateMachine EnemyGeneralStateMachine { get; }

    public sealed override EntityGeneralStateMachine EntityGeneralStateMachine => this.EnemyGeneralStateMachine;

    public EnemyController EnemyController => this.EnemyGeneralStateMachine.EnemyController;

    protected sealed override void OnEntityStateEnter()
    {
        this.OnEnemyStateEnter();
    }

    protected virtual void OnEnemyStateEnter()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntityStateUpdate()
    {
        this.OnEnemyStateUpdate();
    }

    protected virtual void OnEnemyStateUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntityStateExit()
    {
        this.OnEnemyStateExit();
    }

    protected virtual void OnEnemyStateExit()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
