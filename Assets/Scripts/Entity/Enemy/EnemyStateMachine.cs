#nullable enable

namespace Game;

using UnityEngine;

public abstract partial class EnemyStateMachine : EntityStateMachine
{
    [field: Header("Idle State")]
    [field: SerializeField]
    [field: Range(0.5F, 5.0F)]
    public float IdleTime { get; private set; } = 2.0F;

    public abstract EnemyController EnemyController { get; }

    public sealed override EntityController EntityController => this.EnemyController;
}
