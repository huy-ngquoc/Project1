#nullable enable

namespace Game;

using UnityEngine;

public abstract class PlayerThrowSwordSkillController : MonoBehaviour
{
    public float GravityScale { get; private set; } = 0;

    public float FreezeTimeDuration { get; private set; } = 0;

    public float ReturningSpeed { get; private set; } = float.MaxValue;

    public bool CanRotate { get; private set; } = true;

    public bool IsReturning { get; protected set; } = false;

    public PlayerController PlayerController { get; private set; } = null!;

    [field: SerializeField]
    [field: Range(3, 20)]
    public float MaxExistingTime { get; private set; } = 7;

    [field: SerializeReference]
    [field: ResolveComponent]
    protected Rigidbody2D Rigidbody2D { get; private set; } = null!;

    [field: SerializeField]
    [field: ResolveComponent]
    protected CircleCollider2D CircleCollider2D { get; private set; } = null!;

    [field: SerializeReference]
    [field: ResolveComponentInChildren("Animator")]
    protected Animator Animator { get; private set; } = null!;

    public void SetupSword(PlayerController playerController, Vector2 direction, float gravityScale, float freezeTimeDuration, float returningSpeed)
    {
        this.IsReturning = false;
        this.PlayerController = playerController;
        this.Rigidbody2D.linearVelocity = direction;
        this.Rigidbody2D.gravityScale = gravityScale;
        this.GravityScale = gravityScale;
        this.FreezeTimeDuration = freezeTimeDuration;
        this.ReturningSpeed = returningSpeed;

        this.Animator.SetBool(AnimationNameConstants.Bool.Rotation, true);

        this.Invoke(nameof(this.SelfDestroy), this.MaxExistingTime);
    }

    public void ReturnSword()
    {
        this.Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;

        this.transform.parent = null;
        this.CanRotate = false;
        this.IsReturning = true;

        this.OnReturingSword();
    }

    protected virtual void OnReturingSword()
    {
    }

    protected void Awake()
    {
        this.OnAwake();
    }

    protected virtual void OnAwake()
    {
    }

    protected void Update()
    {
        if (this.CanRotate)
        {
            this.transform.right = this.Rigidbody2D.linearVelocity.normalized;
        }

        if (!this.IsReturning)
        {
            this.OnUpdate();
            return;
        }

        this.transform.position = Vector2.MoveTowards(
            this.transform.position,
            this.PlayerController.transform.position,
            this.ReturningSpeed * Time.deltaTime);

        if (Vector2.Distance(this.transform.position, this.PlayerController.transform.position) < 1)
        {
            var playerGeneralStateMachine = this.PlayerController.PlayerGeneralStateMachine;
            playerGeneralStateMachine.SetStateToChangeTo(playerGeneralStateMachine.CatchSwordState);
        }

        this.OnUpdate();
    }

    protected virtual void OnUpdate()
    {
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (this.IsReturning)
        {
            return;
        }

        if (collision.gameObject.TryGetComponent<EnemyController>(out var enemyController))
        {
            this.SwordSkillDamage(enemyController);
            this.OnSwordHitEnemy(enemyController);
        }
        if(collision.gameObject.TryGetComponent<HealthController>(out var healthController)) {
            healthController.TakeDamage(healthController.TakeDamageAt(2));
            this.StuckIntoObject(healthController.gameObject.transform);
        }
        else
        {
            this.StuckIntoObject(collision.transform);
        }
    }

    protected virtual void OnSwordHitEnemy(EnemyController enemyController)
    {
    }

    protected void SwordSkillDamage(EnemyController enemyController)
    {
        this.PlayerController.PlayerStats.DoDamage(enemyController.EntityStats);
        enemyController.EnemyGeneralStateMachine.FreezeForSeconds(this.FreezeTimeDuration);
    }

    protected void StopRotating()
    {
        this.CanRotate = false;
        this.CircleCollider2D.enabled = false;
        this.Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        this.Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    protected void StuckIntoObject(Transform transform)
    {
        this.StopRotating();
        this.Animator.SetBool(AnimationNameConstants.Bool.Rotation, false);
        this.transform.parent = transform;
    }

    private void SelfDestroy()
    {
        Object.Destroy(this.gameObject);
    }
}
