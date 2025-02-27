#nullable enable

namespace Game;

public abstract class EnemyStateMachine : EntityStateMachine
{
    public EnemyController? EnemyController { get; private set; }

    protected sealed override void OnEntityStateMachineValidate()
    {
        this.EnemyController = (EnemyController?)this.EntityController;

        this.OnEnemyStateMachineValidate();
    }

    protected virtual void OnEnemyStateMachineValidate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
