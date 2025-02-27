#nullable enable

namespace Game;
public abstract class PlayerGroundedState : PlayerState
{
    protected PlayerGroundedState(PlayerStateMachine stateMachine, string animationBoolName)
        : base(stateMachine, animationBoolName)
    {
    }

    protected sealed override void OnPlayerStateEnter()
    {
        this.OnPlayerGroundedStateEnter();
    }

    protected virtual void OnPlayerGroundedStateEnter()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnPlayerStateUpdate()
    {
        if (this.PlayerInputHandler.UnityAccessVal(p => p.JumpPressed, false) &&
            this.PlayerStateMachine.UnityAccess(p => p.SetStateToChangeTo(p.JumpState)))
        {
            return;
        }

        this.OnPlayerGroundedStateUpdate();
    }

    protected virtual void OnPlayerGroundedStateUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected sealed override void OnPlayerStateExit()
    {
        this.OnPlayerGroundedStateExit();
    }

    protected virtual void OnPlayerGroundedStateExit()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
