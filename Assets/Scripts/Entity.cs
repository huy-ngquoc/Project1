#nullable enable

namespace Game;

using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [field: Header("Collision info")]
    [field: SerializeField]
    private Transform? groundCheck = null;

    [field: SerializeField]
    public Animator? Animator { get; private set; } = null;

    [field: SerializeField]
    public Rigidbody2D? Rigidbody2D { get; private set; } = null;

    [field: SerializeField]
    public SpriteRenderer? SpriteRenderer { get; private set; } = null;

    public bool FacingRight { get; private set; } = true;

    public sbyte FacingDirection => this.FacingRight ? (sbyte)1 : (sbyte)-1;

    [field: SerializeField]
    [field: Range(0.01F, 0.2F)]
    public float GroundCheckDistance { get; private set; } = 0.1F;

    [field: SerializeField]
    public LayerMask WhatIsGround { get; private set; } = new LayerMask();

    public bool IsGroundDetected()
    {
        if (this.groundCheck != null)
        {
            return Physics2D.Raycast(this.groundCheck.position, Vector2.down, this.GroundCheckDistance, this.WhatIsGround);
        }

        return false;
    }

    protected void FlipController(float x)
    {
        bool flip = false;

        if (this.GetComponent<Rigidbody2D>() != null)
        {
            flip = this.FacingRight ? (x < 0) : (x > 0);
        }

        if (flip)
        {
            this.Flip();
        }
    }

    protected void Flip()
    {
        this.FacingRight = !this.FacingRight;
        this.transform.Rotate(0F, 180F, 0F);
    }

    protected bool SetLinearVelocity(float x, float y)
    {
        return this.SetLinearVelocity(new Vector2(x, y));
    }

    protected bool SetLinearVelocity(Vector2 newLinearVelocity)
    {
        if (this.Rigidbody2D != null)
        {
            this.Rigidbody2D.linearVelocity = newLinearVelocity;
            this.FlipController(newLinearVelocity.x);
            return true;
        }

        return false;
    }

    protected bool SetZeroLinearVelocity()
    {
        if (this.Rigidbody2D != null)
        {
            this.Rigidbody2D.linearVelocity = Vector2.zero;
            return true;
        }

        return false;
    }

    protected bool SetLinearVelocityX(float newLinearVelocityX)
    {
        if (this.Rigidbody2D != null)
        {
            this.Rigidbody2D.linearVelocityX = newLinearVelocityX;
            this.FlipController(newLinearVelocityX);
            return true;
        }

        return false;
    }

    protected bool SetZeroLinearVelocityX()
    {
        if (this.Rigidbody2D != null)
        {
            this.Rigidbody2D.linearVelocityX = 0;
            return true;
        }

        return false;
    }

    protected bool SetLinearVelocityY(float newLinearVelocityY)
    {
        if (this.Rigidbody2D != null)
        {
            this.Rigidbody2D.linearVelocityY = newLinearVelocityY;
            return true;
        }

        return false;
    }

    protected bool SetZeroLinearVelocityY() => this.SetLinearVelocityY(0);

    protected Vector2? GetLinearVelocity()
    {
        Vector2? result = null;

        if (this.Rigidbody2D != null)
        {
            result = this.Rigidbody2D.linearVelocity;
        }

        return result;
    }

    protected Vector2 GetLinearVelocityOrDefault(Vector2 defaultLinearVelocity)
        => this.GetLinearVelocity().GetValueOrDefault(defaultLinearVelocity);

    protected Vector2 GetLinearVelocityOrZero()
      => this.GetLinearVelocityOrDefault(Vector2.zero);

    protected float? GetLinearVelocityX()
    {
        float? result = null;

        if (this.Rigidbody2D != null)
        {
            result = this.Rigidbody2D.linearVelocityX;
        }

        return result;
    }

    protected float GetLinearVelocityOrDefaultX(float defaultLinearVelocityX)
        => this.GetLinearVelocityX().GetValueOrDefault(defaultLinearVelocityX);

    protected float GetLinearVelocityOrZeroX() => this.GetLinearVelocityOrDefaultX(0);

    protected float? GetLinearVelocityY()
    {
        float? result = null;

        if (this.Rigidbody2D != null)
        {
            result = this.Rigidbody2D.linearVelocityY;
        }

        return result;
    }

    protected float GetLinearVelocityOrDefaultY(float defaultLinearVelocityY)
       => this.GetLinearVelocityY().GetValueOrDefault(defaultLinearVelocityY);

    protected float GetLinearVelocityOrZeroY() => this.GetLinearVelocityOrDefaultY(0);

    protected void Awake()
    {
        this.OnAwake();
    }

    protected virtual void OnAwake()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected void Start()
    {
        this.OnStart();
    }

    protected virtual void OnStart()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected void Update()
    {
        this.OnUpdate();
    }

    protected virtual void OnUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected virtual void OnDrawGizmos()
    {
        if (this.groundCheck != null)
        {
            Gizmos.DrawLine(this.groundCheck.position, new Vector3(this.groundCheck.position.x, this.groundCheck.position.y - this.GroundCheckDistance));
        }

        this.OnDrawGizmozEntity();
    }

    protected virtual void OnDrawGizmozEntity()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
