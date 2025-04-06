#nullable enable

namespace Game;

public abstract class EnemySkillManager : EntitySkillManager
{
    public abstract EnemyController EnemyController { get; }

    public sealed override EntityController EntityController => this.EnemyController;
}
