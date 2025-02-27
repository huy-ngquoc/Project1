#nullable enable

namespace Game;

using System;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(EntityStateMachine))]
public abstract class EntityController : MonoBehaviour
{
    [field: SerializeField]
    [field: ReadOnlyInInspector]
    public EntityStateMachine? EntityStateMachine { get; private set; } = null;

    [field: SerializeField]
    [field: ReadOnlyInInspector]
    public Rigidbody2D? Rigidbody2D { get; private set; } = null;

    [field: Header("Animation info")]

    [field: SerializeField]
    public string AnimatorChildObjectName { get; private set; } = "Animator";

    [field: SerializeField]
    [field: ReadOnlyInInspector]
    public SpriteRenderer? SpriteRenderer { get; private set; } = null;

    [field: SerializeField]
    [field: ReadOnlyInInspector]
    public Animator? Animator { get; private set; } = null;

    [field: Header("Collision info")]

    [field: SerializeField]
    public string GroundCheckChildObjectName { get; private set; } = "GroundCheck";

    [field: SerializeField]
    [field: ReadOnlyInInspector]
    public Transform? GroundCheck { get; private set; } = null;

    [field: SerializeField]
    [field: Range(0.01F, 2)]
    public float GroundCheckDistance { get; private set; } = 0.1F;

    [field: SerializeField]
    public LayerMask WhatIsGround { get; private set; } = new LayerMask();

    public bool FacingRight { get; private set; } = true;

    public int FacingDirection => this.FacingRight ? 1 : -1;

    public bool IsGroundDetected()
    {
        if (this.GroundCheck != null)
        {
            return Physics2D.Raycast(this.GroundCheck.position, Vector2.down, this.GroundCheckDistance, this.WhatIsGround);
        }

        return false;
    }

    public void FlipController(float x)
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

    public void Flip()
    {
        this.FacingRight = !this.FacingRight;
        this.transform.Rotate(0F, 180F, 0F);
    }

    public bool SetLinearVelocity(float x, float y)
    {
        return this.SetLinearVelocity(new Vector2(x, y));
    }

    public bool SetLinearVelocity(Vector2 newLinearVelocity)
    {
        if (this.Rigidbody2D != null)
        {
            this.Rigidbody2D.linearVelocity = newLinearVelocity;
            this.FlipController(newLinearVelocity.x);
            return true;
        }

        return false;
    }

    public bool SetZeroLinearVelocity()
    {
        if (this.Rigidbody2D != null)
        {
            this.Rigidbody2D.linearVelocity = Vector2.zero;
            return true;
        }

        return false;
    }

    public bool SetLinearVelocityX(float newLinearVelocityX)
    {
        if (this.Rigidbody2D != null)
        {
            this.Rigidbody2D.linearVelocityX = newLinearVelocityX;
            this.FlipController(newLinearVelocityX);
            return true;
        }

        return false;
    }

    public bool SetZeroLinearVelocityX()
    {
        if (this.Rigidbody2D != null)
        {
            this.Rigidbody2D.linearVelocityX = 0;
            return true;
        }

        return false;
    }

    public bool SetLinearVelocityY(float newLinearVelocityY)
    {
        if (this.Rigidbody2D != null)
        {
            this.Rigidbody2D.linearVelocityY = newLinearVelocityY;
            return true;
        }

        return false;
    }

    public bool SetZeroLinearVelocityY() => this.SetLinearVelocityY(0);

    public Vector2? GetLinearVelocity()
    {
        Vector2? result = null;

        if (this.Rigidbody2D != null)
        {
            result = this.Rigidbody2D.linearVelocity;
        }

        return result;
    }

    public Vector2 GetLinearVelocityOrDefault(Vector2 defaultLinearVelocity)
         => this.GetLinearVelocity().GetValueOrDefault(defaultLinearVelocity);

    public Vector2 GetLinearVelocityOrZero()
       => this.GetLinearVelocityOrDefault(Vector2.zero);

    public float? GetLinearVelocityX()
    {
        float? result = null;

        if (this.Rigidbody2D != null)
        {
            result = this.Rigidbody2D.linearVelocityX;
        }

        return result;
    }

    public float GetLinearVelocityOrDefaultX(float defaultLinearVelocityX)
         => this.GetLinearVelocityX().GetValueOrDefault(defaultLinearVelocityX);

    public float GetLinearVelocityOrZeroX() => this.GetLinearVelocityOrDefaultX(0);

    public float? GetLinearVelocityY()
    {
        float? result = null;

        if (this.Rigidbody2D != null)
        {
            result = this.Rigidbody2D.linearVelocityY;
        }

        return result;
    }

    public float GetLinearVelocityOrDefaultY(float defaultLinearVelocityY)
        => this.GetLinearVelocityY().GetValueOrDefault(defaultLinearVelocityY);

    public float GetLinearVelocityOrZeroY() => this.GetLinearVelocityOrDefaultY(0);

    protected void Awake()
    {
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

    protected virtual void OnEntityControllerUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected void OnValidate()
    {
        this.EntityStateMachine = this.ResolveComponentInChildren<EntityStateMachine>();
        this.Rigidbody2D = this.ResolveComponent<Rigidbody2D>();
        this.SpriteRenderer = this.ResolveComponentInChildren<SpriteRenderer>(this.AnimatorChildObjectName);
        this.Animator = this.ResolveComponentInChildren<Animator>(this.AnimatorChildObjectName);
        this.GroundCheck = this.ResolveComponentInChildren<Transform>(this.GroundCheckChildObjectName);

        Debug.AssertFormat(this.WhatIsGround != new LayerMask(), $"Ground is nothing for Game Object `{this.gameObject.name}`?");

        this.OnEntityControllerValidate();
    }

    protected virtual void OnEntityControllerValidate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected void OnDrawGizmos()
    {
        if (this.GroundCheck != null)
        {
            Gizmos.DrawLine(this.GroundCheck.position, new Vector3(this.GroundCheck.position.x, this.GroundCheck.position.y - this.GroundCheckDistance));
        }

        this.OnEntityControllerDrawGizmos();
    }

    protected virtual void OnEntityControllerDrawGizmos()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
