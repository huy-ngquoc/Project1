#nullable enable

namespace Game;

using UnityEngine;

public abstract class PlayerSkillController : EntitySkillController
{
    protected PlayerController PlayerController { get; set; } = null!;

    protected sealed override EntityController EntityController => this.PlayerController;

    protected sealed override void OnEntitySkillControllerAwake()
    {
        this.OnPlayerSkillControllerAwake();
    }

    protected virtual void OnPlayerSkillControllerAwake()
    {
    }

    protected sealed override void OnEntitySkillControllerUpdate()
    {
        this.OnPlayerSkillControllerUpdate();
    }

    protected virtual void OnPlayerSkillControllerUpdate()
    {
    }

    protected sealed override void OnEntitySkillControllerTriggerEnter2D(Collider2D collision)
    {
        this.OnPlayerSkillControllerTriggerEnter2D(collision);
    }

    protected virtual void OnPlayerSkillControllerTriggerEnter2D(Collider2D collision)
    {
    }
}
