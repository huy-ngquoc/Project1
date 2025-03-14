#nullable enable

namespace Game;

public abstract class PlayerState : EntityState
{
    public abstract PlayerGeneralStateMachine PlayerGeneralStateMachine { get; }

    public sealed override EntityGeneralStateMachine EntityGeneralStateMachine => this.PlayerGeneralStateMachine;

    public PlayerController PlayerController => this.PlayerGeneralStateMachine.PlayerController;

    public PlayerInputHandler PlayerInputHandler => this.PlayerController.InputHandler;

    protected sealed override void OnEntityStateEnter()
    {
        this.OnPlayerStateEnter();
    }

    protected sealed override void OnEntityStateUpdate()
    {
        var animator = this.PlayerController.Animator;
        var velocityY = this.PlayerController.Rigidbody2D.linearVelocityY;
        animator.SetFloat("VelocityY", velocityY);

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
