#nullable enable

namespace Game;
public abstract class EnemyController : EntityController
{
    public abstract EnemyStateMachine EnemyStateMachine { get; }

    public sealed override EntityStateMachine EntityStateMachine => this.EnemyStateMachine;

    protected sealed override void OnEntityControllerAwake()
    {
        this.OnEnemyControllerAwake();
    }

    protected virtual void OnEnemyControllerAwake()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntityControllerStart()
    {
        this.OnEnemyControllerStart();
    }

    protected virtual void OnEnemyControllerStart()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntityControllerUpdate()
    {
        this.OnEnemyControllerUpdate();
    }

    protected virtual void OnEnemyControllerUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntityControllerDestroy()
    {
        this.OnEnemyControllerDestroy();
    }

    protected virtual void OnEnemyControllerDestroy()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntityControllerValidate()
    {
        this.OnEnemyControllerValidate();
    }

    protected virtual void OnEnemyControllerValidate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntityControllerDrawGizmos()
    {
        this.OnEnemyControllerDrawGizmos();
    }

    protected virtual void OnEnemyControllerDrawGizmos()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
