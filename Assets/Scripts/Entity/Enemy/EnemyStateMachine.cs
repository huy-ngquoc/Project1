#nullable enable

namespace Game;

public abstract class EnemyStateMachine : EntityStateMachine
{
    public abstract EnemyController? EnemyController { get; }

    public sealed override EntityController? EntityController => this.EnemyController;
}
