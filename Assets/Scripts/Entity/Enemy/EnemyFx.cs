#nullable enable

namespace Game;

public abstract class EnemyFx : EntityFx
{
    public abstract EnemyController EnemyController { get; }

    public sealed override EntityController EntityController => this.EnemyController;
}
