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
        var playerController = this.PlayerController;
        var playerInputHandler = this.PlayerInputHandler;

        if (!playerController.IsGroundDetected)
        {
            playerGeneralStateMachine.SetStateToChangeTo(playerGeneralStateMachine.FallState);
            return;
        }

        if (playerInputHandler.JumpPressed)
        {
            playerGeneralStateMachine.SetStateToChangeTo(playerGeneralStateMachine.JumpState);
            return;
        }

        if (playerInputHandler.PrimaryAttackPressed && this.PlayerSkillManager.PrimaryAttackSkill.Cast())
        {
            return;
        }

        if (playerInputHandler.AimSwordPressed)
        {
            if (this.PlayerSkillManager.ThrowSwordSkill.IsUsable())
            {
                playerGeneralStateMachine.SetStateToChangeTo(playerGeneralStateMachine.AimSwordState);
                return;
            }
            else if (this.PlayerSkillManager.ThrowSwordSkill.HasSword())
            {
                this.PlayerSkillManager.ThrowSwordSkill.ReturnTheSword();
                return;
            }
            else
            {
                // Do nothing...
            }
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
