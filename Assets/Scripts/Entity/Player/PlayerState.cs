#nullable enable

namespace Game;

using Input = UnityEngine.Input;

public abstract class PlayerState : EntityState
{
    protected PlayerState(PlayerStateMachine stateMachine, string animationBoolName)
        : base(stateMachine, animationBoolName)
    {
        this.PlayerStateMachine = stateMachine;
    }

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

    protected PlayerStateMachine PlayerStateMachine { get; }

    protected PlayerController PlayerController => this.PlayerStateMachine.PlayerController;

    protected sealed override void OnEntityStateEnter()
    {
        this.OnPlayerStateEnter();
    }

    protected sealed override void OnEntityStateUpdate()
    {
        if (this.PlayerController.Animator != null)
        {
            this.PlayerController.Animator.SetFloat("VelocityY", this.PlayerController.Rigidbody2D.UnityAccessVal(r => r.linearVelocityY, 0));
        }

        this.OnPlayerStateUpdate();
    }

    protected sealed override void OnEntityStateExit()
    {
        this.OnPlayerStateExit();
    }

    protected virtual void OnPlayerStateEnter()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected virtual void OnPlayerStateUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected virtual void OnPlayerStateExit()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
