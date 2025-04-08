#nullable enable

namespace Game;

using UnityEngine;

[DisallowMultipleComponent]
public abstract class EntitySkillController : MonoBehaviour
{
    protected abstract EntityController EntityController { get; }

    protected void Awake()
    {
        this.OnEntitySkillControllerAwake();
    }

    protected virtual void OnEntitySkillControllerAwake()
    {
    }

    protected void Update()
    {
        this.OnEntitySkillControllerUpdate();
    }

    protected virtual void OnEntitySkillControllerUpdate()
    {
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        this.OnEntitySkillControllerTriggerEnter2D(collision);
    }

    protected virtual void OnEntitySkillControllerTriggerEnter2D(Collider2D collision)
    {
    }
}
