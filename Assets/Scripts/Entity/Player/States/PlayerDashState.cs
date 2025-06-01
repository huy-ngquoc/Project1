#nullable enable

namespace Game;
public sealed class PlayerDashState : PlayerState
{
    public PlayerDashState(PlayerGeneralStateMachine playerGeneralStateMachine)
    {
        this.PlayerGeneralStateMachine = playerGeneralStateMachine;
    }

    public override PlayerGeneralStateMachine PlayerGeneralStateMachine { get; }

    public override string AnimationBoolName => AnimationNameConstants.Bool.Dash;

    public PlayerDashSkill DashSkill => this.PlayerSkillManager.DashSkill.CurrentDashSkill;

    public float DashSpeed => this.DashSkill.DashSpeed;

    public float DashDuration => this.DashSkill.DashDuration;

    public int DashDirection
    {
        get
        {
            var result = this.PlayerController.FacingDirection;

            var moveInputX = this.PlayerInputHandler.MoveInputX;
            if (moveInputX > 0)
            {
                result = 1;
            }
            else if (moveInputX < 0)
            {
                result = -1;
            }
            else
            {
                // Do nothing...
            }

            return result;
        }
    }

    protected override void OnPlayerStateEnter()
    {
        this.StateTimer = this.DashDuration;
    }

    protected override void OnPlayerStateUpdate()
    {
        var playerController = this.PlayerController;

        if (this.StateTimer > 0)
        {
            playerController.SetLinearVelocity(this.DashSpeed * this.DashDirection, 0);
            return;
        }

        var generalStateMachine = this.PlayerGeneralStateMachine;
        if (!playerController.IsGroundDetected)
        {
            generalStateMachine.SetStateToChangeTo(generalStateMachine.FallState);
            return;
        }

        generalStateMachine.SetStateToChangeTo(generalStateMachine.GroundedState);
    }

    protected override void OnPlayerStateExit()
    {
        this.PlayerInputHandler.CancelDashAction();
        this.PlayerController.SetZeroLinearVelocityX();
    }
}
