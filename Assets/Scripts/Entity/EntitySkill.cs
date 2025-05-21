#nullable enable

namespace Game;

using UnityEngine;

public abstract class EntitySkill : MonoBehaviour
{
    public abstract EntitySkillManager EntitySkillManager { get; }

    public EntityController EntityController => this.EntitySkillManager.EntityController;

    [field: SerializeField]
    [field: Range(0, 60)]
    public float Cooldown { get; protected set; } = 0;

    public float CooldownTimer { get; protected set; } = 0;

    public virtual bool IsUsable() => this.CooldownTimer <= 0;

    public bool Cast()
    {
        if (!this.IsUsable())
        {
            Debug.Log("Skill is on cooldown.");
            return false;
        }

        this.CastLogic();
        this.CooldownTimer = this.Cooldown;
        return true;
    }

    protected abstract void CastLogic();

    protected void Awake()
    {
        this.OnEntitySkillAwake();
    }

    protected virtual void OnEntitySkillAwake()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected void Update()
    {
        var deltaTime = Time.deltaTime;
        if (this.CooldownTimer > deltaTime)
        {
            this.CooldownTimer -= deltaTime;
        }
        else
        {
            this.CooldownTimer = 0;
        }

        this.OnEntitySkillUpdate();
    }

    protected virtual void OnEntitySkillUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
