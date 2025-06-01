#nullable enable

namespace Game;

using UnityEngine;

[RequireComponent(typeof(PlayerSkillManager))]
public abstract class PlayerSkill : EntitySkill
{
    public abstract PlayerSkillManager PlayerSkillManager { get; }
    public int skillId;

    public PlayerController PlayerController => this.PlayerSkillManager.PlayerController;

    public PlayerGeneralStateMachine PlayerGeneralStateMachine => this.PlayerController.PlayerGeneralStateMachine;

    public sealed override EntitySkillManager EntitySkillManager => this.PlayerSkillManager;
    public override bool IsUsable() {
        bool coolDown = this.CooldownTimer<=0;
        int isChose = PlayerPrefs.GetInt("Chosen_Skill",-1);
        if(skillId==1) {
            return coolDown;
        }
        return (coolDown&isChose==skillId);
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
