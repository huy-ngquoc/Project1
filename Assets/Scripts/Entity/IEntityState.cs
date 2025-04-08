#nullable enable

namespace Game;

public interface IEntityState
{
    EntityGeneralStateMachine EntityGeneralStateMachine { get; }

    void Enter();

    void Update();

    void Exit();

    void AnimationFinishTrigger();
}
