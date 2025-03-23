#nullable enable

namespace Game;

using UnityEngine;

public abstract partial class EnemyGeneralStateMachine : EntityGeneralStateMachine
{
    [field: Header("Idle State")]
    [field: SerializeField]
    [field: Range(0.5F, 5.0F)]
    public float IdleTime { get; private set; } = 2.0F;

    [field: SerializeField]
    [field: Range(0, 5)]
    public float AttackCooldown { get; private set; } = 0.4F;

    public abstract EnemyController EnemyController { get; }

    public sealed override EntityController EntityController => this.EnemyController;
}
