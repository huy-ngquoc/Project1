#nullable enable

namespace Game;

public abstract class EnemySkill : EntitySkill
{
    public abstract EnemySkillManager EnemySkillManager { get; }

    public sealed override EntitySkillManager EntitySkillManager => this.EnemySkillManager;

    protected sealed override void OnEntitySkillAwake()
    {
        this.OnEnemySkillAwake();
    }

    protected virtual void OnEnemySkillAwake()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntitySkillUpdate()
    {
        this.OnEnemySkillUpdate();
    }

    protected virtual void OnEnemySkillUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}