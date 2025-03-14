#nullable enable

namespace Game;

public abstract class EnemySpecificStateMachine : EntitySpecificStateMachine
{
    public abstract EnemyGeneralStateMachine EnemyGeneralStateMachine { get; }

    public sealed override EntityGeneralStateMachine EntityGeneralStateMachine => this.EnemyGeneralStateMachine;

    public EnemyController EnemyController => this.EnemyGeneralStateMachine.EnemyController;
}
