#nullable enable

namespace Game;

public abstract partial class EnemyStateMachine : EntityStateMachine
{
    protected EnemyStateMachine(EnemyController enemyController)
        : base(enemyController)
    {
        this.EnemyController = enemyController;
    }

    public EnemyController EnemyController { get; }
}
