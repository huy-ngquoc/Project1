#nullable enable

namespace Game;

public abstract class PlayerSpecificStateMachine : EntitySpecificStateMachine
{
    public abstract PlayerGeneralStateMachine PlayerGeneralStateMachine { get; }

    public sealed override EntityGeneralStateMachine EntityGeneralStateMachine => this.PlayerGeneralStateMachine;

    public PlayerController PlayerController => this.PlayerGeneralStateMachine.PlayerController;

    public PlayerInputHandler PlayerInputHandler => this.PlayerController.InputHandler;
}
