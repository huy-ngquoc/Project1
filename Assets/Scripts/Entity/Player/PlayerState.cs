#nullable enable

namespace Game;
public abstract class PlayerState : EntityState
{
    public UnityEngine.Vector2 MoveInput => this.PlayerInputHandler.UnityAccessVal(p => p.MoveInput, UnityEngine.Vector2.zero);

    protected abstract PlayerStateMachine PlayerStateMachine { get; }

    protected sealed override EntityStateMachine EntityStateMachine => this.PlayerStateMachine;

    protected PlayerController? PlayerController => this.PlayerStateMachine.PlayerController;

    protected PlayerInputHandler? PlayerInputHandler => this.PlayerController.UnityAccessRef(p => p.InputHandler);

    protected sealed override void OnEntityStateEnter()
    {
        this.OnPlayerStateEnter();
    }

    protected sealed override void OnEntityStateUpdate()
    {
        var animator = this.PlayerController.UnityAccessRef(p => p.Animator);
        if (animator != null)
        {
            var velocityY = this.PlayerController.UnityAccessRef(p => p.Rigidbody2D).UnityAccessVal(r => r.linearVelocityY, 0);
            animator.SetFloat("VelocityY", velocityY);
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
