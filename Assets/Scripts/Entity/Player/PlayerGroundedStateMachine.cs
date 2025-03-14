#nullable enable

namespace Game;

public sealed class PlayerGroundedStateMachine : PlayerSpecificStateMachine
{
    public PlayerGroundedStateMachine(PlayerGeneralStateMachine playerGeneralStateMachine)
    {
        this.PlayerGeneralStateMachine = playerGeneralStateMachine;

        this.IdleState = new PlayerIdleState(this);
        this.MoveState = new PlayerMoveState(this);
    }

    public override PlayerGeneralStateMachine PlayerGeneralStateMachine { get; }

    public override IEntityState InitialState
    {
        get
        {
            var playerInputHandler = this.PlayerInputHandler;
            if (playerInputHandler.MoveInputXInt != 0)
            {
                return this.MoveState;
            }
            else
            {
                return this.IdleState;
            }
        }
    }

    public PlayerIdleState IdleState { get; }

    public PlayerMoveState MoveState { get; }
}
