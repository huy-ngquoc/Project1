#nullable enable

namespace Game;

using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [field: SerializeField] public Animator? Animator { get; private set; } = null;
    [field: SerializeField] public Rigidbody2D? Rigidbody2D { get; private set; } = null;
    [field: SerializeField] public SpriteRenderer? SpriteRenderer { get; private set; } = null;

    public bool FacingRight { get; private set; } = true;

    public sbyte FacingDirection => this.FacingRight ? (sbyte)(1) : (sbyte)(-1);

    protected void Awake()
    {
        this.OnAwake();
    }

    protected virtual void OnAwake() { }

    protected void Start()
    {
        this.OnStart();
    }

    protected virtual void OnStart() { }

    protected void Update()
    {
        this.OnUpdate();
    }

    protected virtual void OnUpdate() { }

    public virtual void FlipController(float x)
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

    public virtual void Flip()
    {
        this.FacingRight = !this.FacingRight;
        this.transform.Rotate(0F, 180F, 0F);
    }
}
