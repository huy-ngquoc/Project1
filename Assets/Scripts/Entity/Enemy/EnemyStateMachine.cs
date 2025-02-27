#nullable enable

namespace Game;

public abstract partial class EnemyStateMachine : EntityStateMachine
{
    public EnemyController? EnemyController => this.EntityController as EnemyController;
}
