#nullable enable

namespace Game;

public abstract class PlayerPrimaryAttackState : PlayerState
{
    public abstract PlayerPrimaryAttackStateMachine PlayerPrimaryAttackStateMachine { get; }

    public sealed override PlayerGeneralStateMachine PlayerGeneralStateMachine => this.PlayerPrimaryAttackStateMachine.PlayerGeneralStateMachine;

    protected override void OnPlayerStateEnter()
    {
        this.PlayerController.SetZeroLinearVelocityX();

        this.OnPlayerPrimaryAttackStateEnter();
    }

    protected virtual void OnPlayerPrimaryAttackStateEnter()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected override void OnPlayerStateUpdate()
    {
        if (this.TriggerCalled)
        {
            this.PlayerGeneralStateMachine.SetStateToChangeTo(this.PlayerGeneralStateMachine.GroundedState);
            return;
        }

        this.OnPlayerPrimaryAttackStateUpdate();
    }

    protected virtual void OnPlayerPrimaryAttackStateUpdate()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }

    protected override void OnPlayerStateExit()
    {
        this.PlayerInputHandler.CancelPrimaryAttackInputAction();

        this.OnPlayerPrimaryAttackStateExit();
    }

    protected virtual void OnPlayerPrimaryAttackStateExit()
    {
        // Leave this method blank
        // The derived classes can decide if they override this method
    }
}
