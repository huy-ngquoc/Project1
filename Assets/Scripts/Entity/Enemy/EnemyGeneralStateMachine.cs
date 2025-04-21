#nullable enable

namespace Game;

using System.Collections;
using UnityEngine;

public abstract partial class EnemyGeneralStateMachine : EntityGeneralStateMachine
{
    private Coroutine? freezeCoroutine;

    [field: Header("Idle State")]
    [field: SerializeField]
    [field: Range(0.5F, 5.0F)]
    public float IdleTime { get; private set; } = 2.0F;

    [field: SerializeField]
    [field: Range(0, 5)]
    public float AttackCooldown { get; private set; } = 0.4F;

    public abstract EnemyController EnemyController { get; }

    public sealed override EntityController EntityController => this.EnemyController;

    protected virtual EnemyState? EnemyFreezeState { get; } = null;

    public void FreezeForSeconds(float seconds)
    {
        if (this.freezeCoroutine != null)
        {
            this.StopCoroutine(this.freezeCoroutine);
        }

        this.freezeCoroutine = this.StartCoroutine(this.FreezeLogic(seconds));
    }

    private IEnumerator FreezeLogic(float seconds)
    {
        if (this.EnemyFreezeState == null)
        {
            yield break;
        }

        this.SetStateToChangeTo(this.EnemyFreezeState);
        yield return new WaitForSeconds(seconds);
        this.SetStateToLastState();

        this.freezeCoroutine = null;
    }
}
