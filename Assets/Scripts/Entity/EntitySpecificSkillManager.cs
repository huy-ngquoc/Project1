#nullable enable

namespace Game;

using UnityEngine;

public abstract class EntitySpecificSkillManager : MonoBehaviour, IEntitySkill
{
    public abstract EntitySkillManager EntitySkillManager { get; }

    public abstract bool IsUsable();

    public abstract bool Cast();

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
