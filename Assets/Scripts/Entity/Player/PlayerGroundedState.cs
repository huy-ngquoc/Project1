#nullable enable

namespace Game;

public abstract class PlayerGroundedState : PlayerState
{
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
        var playerStateMachine = this.PlayerStateMachine;
        if (this.JumpPressed)
        {
            playerStateMachine.SetStateToChangeTo(playerStateMachine.JumpState);
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
