#nullable enable

namespace Game;

public abstract class EntityStats : UnityEngine.MonoBehaviour
{
    public abstract EntityController EntityController { get; }

    public void TakeDamage()
    {
        this.OnEntityTakeDamage();

        this.EntityController.DoTakeDamageEffect();
    }

    protected virtual void OnEntityTakeDamage()
    {
    }
}