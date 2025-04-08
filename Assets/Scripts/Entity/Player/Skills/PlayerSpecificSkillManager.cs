#nullable enable

namespace Game;

using UnityEngine;

public abstract class PlayerSpecificSkillManager : EntitySpecificSkillManager
{
    [field: SerializeReference]
    [field: ResolveComponent]
    public PlayerSkillManager PlayerSkillManager { get; private set; } = null!;

    public PlayerController PlayerController => this.PlayerSkillManager.PlayerController;

    public PlayerInputHandler PlayerInputHandler => this.PlayerController.InputHandler;

    public sealed override EntitySkillManager EntitySkillManager => this.PlayerSkillManager;

    protected sealed override void OnEntitySpecificSkillManagerAwake()
    {
        this.OnPlayerSpecificSkillManagerAwake();
    }

    protected virtual void OnPlayerSpecificSkillManagerAwake()
    {
    }

    protected sealed override void OnEntitySpecificSkillManagerUpdate()
    {
        this.OnPlayerSpecificSkillManagerUpdate();
    }

    protected virtual void OnPlayerSpecificSkillManagerUpdate()
    {
    }
}
