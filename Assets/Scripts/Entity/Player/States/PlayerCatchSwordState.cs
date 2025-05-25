#nullable enable

namespace Game;

public sealed class PlayerCatchSwordState : PlayerState
{
    public PlayerCatchSwordState(PlayerGeneralStateMachine playerGeneralStateMachine)
    {
        this.PlayerGeneralStateMachine = playerGeneralStateMachine;
    }

    public override PlayerGeneralStateMachine PlayerGeneralStateMachine { get; }

    public override string AnimationBoolName => AnimationNameConstants.Bool.CatchSword;

    protected override void OnPlayerStateEnter()
    {
        var throwSwordSkill = this.PlayerSkillManager.ThrowSwordSkill;

        var swordPosition = throwSwordSkill.SwordPosition;
        if ((swordPosition != null)
            && ((this.PlayerController.transform.position.x < swordPosition.Value.x) != this.PlayerController.FacingRight))
        {
            this.PlayerController.Flip();
        }

        throwSwordSkill.ClearTheSword();
        this.PlayerController.Rigidbody2D.linearVelocityX = -(throwSwordSkill.ReturnImpact * this.PlayerController.FacingDirection);
    }

    protected override void OnPlayerStateUpdate()
    {
        if (this.TriggerCalled)
        {
            this.PlayerGeneralStateMachine.SetStateToChangeTo(this.PlayerGeneralStateMachine.GroundedState);
        }
    }
}
