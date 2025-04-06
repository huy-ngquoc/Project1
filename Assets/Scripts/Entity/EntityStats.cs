#nullable enable

namespace Game;

using UnityEngine;

public abstract class EntityStats : UnityEngine.MonoBehaviour
{
    public abstract EntityController EntityController { get; }

    [field: SerializeField]
    [field: Range(0, 1000)]
    public int CurrentHealth { get; private set; } = 100;

    [field: SerializeField]
    [field: Range(0, 100)]
    public int Damage { get; private set; } = 5;

    public void DoDamage(EntityStats targetStats)
    {
        targetStats.TakeDamage(this);
    }

    protected virtual void OnEntityTakeDamage()
    {
    }

    private void TakeDamage(EntityStats targetStats)
    {
        this.DecreaseHealthBy(targetStats.Damage);
        this.EntityController.DoTakeDamageEffect(targetStats.EntityController);

        this.OnEntityTakeDamage();
    }

    private void DecreaseHealthBy(int damage)
    {
        this.CurrentHealth -= damage;
    }
}