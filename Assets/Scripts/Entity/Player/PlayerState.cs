#nullable enable

namespace Game;

public abstract class PlayerState : EntityState
{
    public UnityEngine.Vector2Int MoveInputInt => this.PlayerInputHandler.UnityAccessVal(p => p.MoveInputInt, UnityEngine.Vector2Int.zero);

    public int MoveInputXInt => this.PlayerInputHandler.UnityAccessVal(p => p.MoveInputXInt, 0);

    public int MoveInputYInt => this.PlayerInputHandler.UnityAccessVal(p => p.MoveInputYInt, 0);

    public bool JumpPressed => this.PlayerInputHandler.UnityAccessVal(p => p.JumpPressed, false);

    protected abstract PlayerStateMachine PlayerStateMachine { get; }

    protected sealed override EntityStateMachine EntityStateMachine => this.PlayerStateMachine;

    protected PlayerController? PlayerController => this.PlayerStateMachine.PlayerController;

    protected PlayerInputHandler? PlayerInputHandler => this.PlayerController.UnityAccessRef(p => p.InputHandler);

    public void CancelJumpInputAction() => this.PlayerInputHandler.UnityAccess(p => p.CancelJumpInputAction());

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
