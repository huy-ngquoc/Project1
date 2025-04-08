#nullable enable

namespace Game;

using UnityEngine;

public abstract class EntitySpecificSkillManager : MonoBehaviour, IEntitySkill
{
    public abstract EntitySkillManager EntitySkillManager { get; }

    protected abstract IEntitySkill CurrentSkill { get; }

    public bool IsUsable()
    {
        return this.CurrentSkill.IsUsable();
    }

    public bool Cast()
    {
        return this.CurrentSkill.Cast();
    }

    protected void Awake()
    {
        this.OnEntitySpecificSkillManagerAwake();
    }

    protected virtual void OnEntitySpecificSkillManagerAwake()
    {
    }

    protected void Update()
    {
        this.OnEntitySpecificSkillManagerUpdate();
    }

    protected virtual void OnEntitySpecificSkillManagerUpdate()
    {
    }
}
