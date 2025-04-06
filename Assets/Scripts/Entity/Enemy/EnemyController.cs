#nullable enable

namespace Game;

using UnityEngine;

public abstract class EnemyController : EntityController
{
    [field: SerializeField]
    [field: Range(5, 20)]
    public float DetectionRange { get; private set; } = 10;

    [field: SerializeField]
    [field: Range(0.5F, 5)]
    public float AttackRange { get; private set; } = 5;

    public abstract EnemyGeneralStateMachine EnemyGeneralStateMachine { get; }

    public sealed override EntityGeneralStateMachine EntityGeneralStateMachine => this.EnemyGeneralStateMachine;

    public abstract EnemyStats EnemyStats { get; }

    public sealed override EntityStats EntityStats => this.EnemyStats;

    public abstract EnemyFx EnemyFx { get; }

    public sealed override EntityFx EntityFx => this.EnemyFx;

    public abstract EnemySkillManager EnemySkillManager { get; }

    public sealed override EntitySkillManager EntitySkillManager => this.EnemySkillManager;

    public RaycastHit2D IsPlayerDetected
    {
        get
        {
            return Physics2D.Raycast(this.transform.position, Vector2.right * this.FacingDirection, this.DetectionRange, this.AttackTargetLayerMask);
        }
    }

    protected sealed override void OnEntityControllerAwake()
    {
        this.OnEnemyControllerAwake();
    }

    protected virtual void OnEnemyControllerAwake()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntityControllerStart()
    {
        this.OnEnemyControllerStart();
    }

    protected virtual void OnEnemyControllerStart()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntityControllerUpdate()
    {
        this.OnEnemyControllerUpdate();
    }

    protected virtual void OnEnemyControllerUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntityControllerDestroy()
    {
        this.OnEnemyControllerDestroy();
    }

    protected virtual void OnEnemyControllerDestroy()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntityControllerValidate()
    {
        this.OnEnemyControllerValidate();
    }

    protected virtual void OnEnemyControllerValidate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnEntityControllerDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x + (this.DetectionRange * this.FacingDirection), this.transform.position.y));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(this.transform.position, new Vector3(this.transform.position.x + (this.AttackRange * this.FacingDirection), this.transform.position.y));

        this.OnEnemyControllerDrawGizmos();
    }

    protected virtual void OnEnemyControllerDrawGizmos()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
