#nullable enable

namespace Game;

using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerAimSwordState : PlayerState
{
    public PlayerAimSwordState(PlayerGeneralStateMachine playerGeneralStateMachine)
    {
        this.PlayerGeneralStateMachine = playerGeneralStateMachine;
    }

    public override PlayerGeneralStateMachine PlayerGeneralStateMachine { get; }

    public override string AnimationBoolName => AnimationNameConstants.Bool.AimSword;

    protected override void OnPlayerStateEnter()
    {
        this.PlayerController.SetZeroLinearVelocityX();
        this.PlayerSkillManager.ThrowSwordSkill.SetDotsActive();
    }

    protected override void OnPlayerStateUpdate()
    {
        if (!this.PlayerInputHandler.AimSwordPressed)
        {
            var generalStateMachine = this.PlayerGeneralStateMachine;
            generalStateMachine.SetStateToChangeTo(generalStateMachine.GroundedState);
            return;
        }

        var playerController = this.PlayerController;
        var mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if ((playerController.transform.position.x < mousePosition.x) != playerController.FacingRight)
        {
            playerController.Flip();
        }
    }

    protected override void OnPlayerStateExit()
    {
        this.PlayerSkillManager.ThrowSwordSkill.Cast();
    }
}
