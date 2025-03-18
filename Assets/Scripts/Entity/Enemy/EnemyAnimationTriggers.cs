#nullable enable

namespace Game;

public abstract class EnemyAnimationTriggers : EntityAnimationTriggers
{
    public abstract EnemyController EnemyController { get; }

    public sealed override EntityController EntityController => this.EnemyController;
}