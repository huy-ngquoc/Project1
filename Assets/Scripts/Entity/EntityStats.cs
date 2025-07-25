#nullable enable

namespace Game;

using System;
using UnityEngine;

public abstract class EntityStats : UnityEngine.MonoBehaviour
{
    public abstract EntityController EntityController { get; }

    [field: SerializeField]
    [field: Range(0, 10000)]
    public int MaxHealth { get; protected set; } = 1000;

    public int CurrentHealth { get; protected set; } = 1000;

    [field: SerializeField]
    [field: Range(1, 100)]
    public int Damage { get; private set; } = 5;

    public Action? OnHealthChanged { get; set; } = null;

    public void DoDamage(EntityStats targetStats)
    {
        targetStats.TakeDamage(this);
    }

    protected virtual void OnEntityTakeDamage()
    {
    }

    private void TakeDamage(EntityStats attackerStats)
    {
        this.DecreaseHealthBy(attackerStats.Damage);

        var attackerController = attackerStats.EntityController;
        this.EntityController.DoTakeDamageEffect(
           attackerController.FacingDirection, attackerController.KnockbackDirection, attackerController.KnockbackDuration);

        if (this.CurrentHealth <= 0)
        {
            this.EntityController.Die();
        }

        this.OnEntityTakeDamage();
    }

    public void DecreaseHealthBy(int damage)
    {
        this.CurrentHealth -= damage;
        this.OnHealthChanged?.Invoke();
    }

    public void Die()
    {
        this.EntityController.Die();
    }

    public int GetCurrentHealth()
    {
        return this.CurrentHealth;
    }

    protected void Awake()
    {
        this.CurrentHealth = this.MaxHealth;
        this.OnHealthChanged?.Invoke();
    }

    protected virtual void OnEntityStatsAwake()
    {
    }
}