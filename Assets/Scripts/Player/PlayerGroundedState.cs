#nullable enable

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

        this.OnGroundedUpdate();
    }

    protected virtual void OnGroundedUpdate() { }

    protected sealed override void OnExit()
    {
        this.OnGroundedExit();
    }

    protected virtual void OnGroundedExit() { }
}
