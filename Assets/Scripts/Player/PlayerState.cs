#nullable enable

namespace Game;

using Input = UnityEngine.Input;
using Time = UnityEngine.Time;

public abstract class PlayerState
{
    protected Player Player { get; }

    protected PlayerStateMachine? StateMachine => Player.StateMachine;

    private string AnimationBoolName { get; }

    public static sbyte InputY
    {
        get
        {
            var inputY = Input.GetAxisRaw("Vertical");
            if (inputY > 0)
            {
                return 1;
            }
            else if (inputY < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public static sbyte InputX
    {
        get
        {
            var inputX = Input.GetAxisRaw("Horizontal");
            if (inputX > 0)
            {
                return 1;
            }
            else if (inputX < 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public float StateTimer { get; protected set; } = 0.0F;

    public bool TriggerCalled { get; private set; } = false;

    protected PlayerState(Player player, string animationBoolName)
    {
        this.Player = player;
        this.AnimationBoolName = animationBoolName;
    }

    public void Enter()
    {
        this.TriggerCalled = false;
        if (this.Player.Animator != null)
        {
            this.Player.Animator.SetBool(this.AnimationBoolName, true);
        }

        this.OnEnter();
    }

    protected virtual void OnEnter() { }

    public void Update()
    {
        if (this.StateTimer > Time.deltaTime)
        {
            this.StateTimer -= Time.deltaTime;
        }
        else
        {
            this.StateTimer = 0;
        }

        if (this.Player.Animator != null)
        {
            this.Player.Animator.SetFloat("VelocityY", this.Player.Rigidbody2D.UnityAccessVal(r => r.linearVelocityY, 0));
        }

        this.OnUpdate();
    }

    protected virtual void OnUpdate() { }

    public void Exit()
    {
        if (this.Player.Animator != null)
        {
            this.Player.Animator.SetBool(this.AnimationBoolName, false);
        }

        this.OnExit();
    }

    protected virtual void OnExit() { }

    public void AnimationFinishTrigger()
    {
        this.TriggerCalled = true;
    }
}
