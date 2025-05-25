#nullable enable

namespace Game;

public interface IEntityState
{
    EntityGeneralStateMachine EntityGeneralStateMachine { get; }

    string AnimationBoolName { get; }

    void Enter();

    void Update();

    void Exit();

    void AnimationFinishTrigger();
}
