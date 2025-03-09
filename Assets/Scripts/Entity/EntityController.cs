#nullable enable

namespace Game;

using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
public abstract class EntityController : MonoBehaviour
{
    [field: SerializeReference]
    [field: ResolveComponent]
    public Rigidbody2D Rigidbody2D { get; private set; } = null!;

    [field: Header("Animation info")]

    [field: SerializeReference]
    [field: ResolveComponentInChildren("Animator")]
    public SpriteRenderer SpriteRenderer { get; private set; } = null!;

    [field: SerializeReference]
    [field: ResolveComponentInChildren("Animator")]
    public Animator Animator { get; private set; } = null!;

    [field: Header("Collision info")]

    [field: SerializeReference]
    [field: ResolveComponentInChildren("GroundCheck")]
    public Transform GroundCheck { get; private set; } = null!;

    [field: SerializeField]
    [field: Range(0.01F, 2)]
    public float GroundCheckDistance { get; private set; } = 0.1F;

    [field: SerializeField]
    [field: LayerMaskIsNothingOrEverythingWarning]
    public LayerMask WhatIsGround { get; private set; } = new LayerMask();

    public bool IsGroundDetected => Physics2D.Raycast(this.GroundCheck.position, Vector2.down, this.GroundCheckDistance, this.WhatIsGround);

    [field: SerializeReference]
    [field: ResolveComponentInChildren("WallCheck")]
    public Transform WallCheck { get; private set; } = null!;

    [field: SerializeField]
    [field: Range(0.01F, 2)]
    public float WallCheckDistance { get; private set; } = 0.1F;

    [field: SerializeField]
    [field: LayerMaskIsNothingOrEverythingWarning]
    public LayerMask WhatIsWall { get; private set; } = new LayerMask();

    public bool IsWallDetected => Physics2D.Raycast(this.WallCheck.position, Vector2.right * this.FacingDirection, this.WallCheckDistance, this.WhatIsWall);

    [field: Header("Move info")]

    [field: SerializeField]
    [field: Range(0.5F, 30.0F)]
    public float InitMoveSpeed { get; private set; } = 8.0F;

    public float MoveSpeed { get; private set; } = 8.0F;

    public bool FacingRight { get; private set; } = true;

    public int FacingDirection => this.FacingRight ? 1 : -1;

    public abstract EntityStateMachine EntityStateMachine { get; }

    public void FlipController(float x)
    {
        bool flip = this.FacingRight ? (x < 0) : (x > 0);
        if (flip)
        {
            this.Flip();
        }
    }

    public void Flip()
    {
        this.FacingRight = !this.FacingRight;
        this.transform.Rotate(0F, 180F, 0F);
    }

    public void SetLinearVelocity(float x, float y)
    {
        this.SetLinearVelocity(new Vector2(x, y));
    }

    public void SetLinearVelocity(Vector2 newLinearVelocity)
    {
        this.Rigidbody2D.linearVelocity = newLinearVelocity;
        this.FlipController(newLinearVelocity.x);
    }

    public void SetZeroLinearVelocity()
    {
        this.Rigidbody2D.linearVelocity = Vector2.zero;
    }

    public void SetLinearVelocityX(float newLinearVelocityX)
    {
        this.Rigidbody2D.linearVelocityX = newLinearVelocityX;
        this.FlipController(newLinearVelocityX);
    }

    public void SetZeroLinearVelocityX()
    {
        this.Rigidbody2D.linearVelocityX = 0;
    }

    public void SetLinearVelocityY(float newLinearVelocityY)
    {
        this.Rigidbody2D.linearVelocityY = newLinearVelocityY;
    }

    public void SetZeroLinearVelocityY() => this.SetLinearVelocityY(0);

    public Vector2 GetLinearVelocity() => this.Rigidbody2D.linearVelocity;

    protected void Awake()
    {
        this.MoveSpeed = this.InitMoveSpeed;

        this.OnEntityControllerAwake();
    }

    protected virtual void OnEntityControllerAwake()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected void Start()
    {
        this.OnEntityControllerStart();
    }

    protected virtual void OnEntityControllerStart()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected void Update()
    {
        this.OnEntityControllerUpdate();
    }

    protected void OnDestroy()
    {
        this.OnEntityControllerDestroy();
    }

    protected virtual void OnEntityControllerDestroy()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected virtual void OnEntityControllerUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected void OnValidate()
    {
        this.OnEntityControllerValidate();
    }

    protected virtual void OnEntityControllerValidate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected void OnDrawGizmos()
    {
        Gizmos.DrawLine(this.GroundCheck.position, new Vector2(this.GroundCheck.position.x, this.GroundCheck.position.y - this.GroundCheckDistance));
        Gizmos.DrawLine(this.WallCheck.position, new Vector2(this.WallCheck.position.x + (this.WallCheckDistance * this.FacingDirection), this.WallCheck.position.y));

        this.OnEntityControllerDrawGizmos();
    }

    protected virtual void OnEntityControllerDrawGizmos()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
