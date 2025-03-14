#nullable enable

namespace Game;

public abstract class PlayerGroundedState : PlayerState
{
    public abstract PlayerGroundedStateMachine PlayerGroundedStateMachine { get; }

    public sealed override PlayerGeneralStateMachine PlayerGeneralStateMachine => this.PlayerGroundedStateMachine.PlayerGeneralStateMachine;

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
        var playerGeneralStateMachine = this.PlayerGeneralStateMachine;

        if (this.PlayerInputHandler.JumpPressed)
        {
            playerGeneralStateMachine.SetStateToChangeTo(playerGeneralStateMachine.JumpState);
            return;
        }

        if (!this.PlayerController.IsGroundDetected)
        {
            playerGeneralStateMachine.SetStateToChangeTo(playerGeneralStateMachine.FallState);
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
