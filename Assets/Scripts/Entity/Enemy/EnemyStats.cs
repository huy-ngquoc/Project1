#nullable enable

namespace Game;

public abstract class EnemyStats : EntityStats
{
    public abstract EnemyController EnemyController { get; }

    public sealed override EntityController EntityController => this.EnemyController;

    protected sealed override void OnEntityTakeDamage()
    {
        this.OnEnemyTakeDamage();
    }

    protected virtual void OnEnemyTakeDamage()
    {
    }
}