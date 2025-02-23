#nullable enable

using UnityEngine;

namespace Game;
public abstract class PlayerGroundedState : PlayerState
{
    protected PlayerGroundedState(Player player, string animationBoolName)
        : base(player, animationBoolName) { }

    protected sealed override void OnEnter()
    {
        this.OnGroundedEnter();
    }

    protected virtual void OnGroundedEnter() { }

    protected sealed override void OnUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.StateMachine?.ChangeState(this.Player.JumpState);
            return;
        }

        this.OnGroundedUpdate();
    }

    protected virtual void OnGroundedUpdate() { }

    protected sealed override void OnExit()
    {
        this.OnGroundedExit();
    }

    protected virtual void OnGroundedExit() { }
}
