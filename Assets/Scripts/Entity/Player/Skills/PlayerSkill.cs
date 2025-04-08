#nullable enable

namespace Game;

using UnityEngine;

[RequireComponent(typeof(PlayerSkillManager))]
public abstract class PlayerSkill : EntitySkill
{
    public abstract PlayerSkillManager PlayerSkillManager { get; }

    public PlayerController PlayerController => this.PlayerSkillManager.PlayerController;

    public PlayerGeneralStateMachine PlayerGeneralStateMachine => this.PlayerController.PlayerGeneralStateMachine;

    public sealed override EntitySkillManager EntitySkillManager => this.PlayerSkillManager;

    protected sealed override bool IsUsableEntitySkill()
    {
        return this.IsUsablePlayerSkill();
    }

    protected virtual bool IsUsablePlayerSkill()
    {
        return true;
    }

    protected sealed override void OnEntitySkillAwake()
    {
        this.OnPlayerSkillAwake();
    }

    protected virtual void OnPlayerSkillAwake()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntitySkillUpdate()
    {
        this.OnPlayerSkillUpdate();
    }

    protected virtual void OnPlayerSkillUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
