#nullable enable

namespace Game;

public sealed class PlayerStateMachine : EntityStateMachine
{
    public PlayerStateMachine(PlayerController playerController)
        : base(playerController)
    {
        this.PlayerController = playerController;

        this.IdleState = new PlayerIdleState(this, "Idle");
        this.MoveState = new PlayerMoveState(this, "Move");
        this.JumpState = new PlayerJumpState(this, "Jump");
        this.FallState = new PlayerFallState(this, "Jump");

        this.ChangeState(this.IdleState);
    }

    public PlayerController PlayerController { get; }

    public PlayerIdleState IdleState { get; }

    public PlayerMoveState MoveState { get; }

    public PlayerJumpState JumpState { get; }

    public PlayerFallState FallState { get; }
}
