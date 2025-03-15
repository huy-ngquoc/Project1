#nullable enable

namespace Game;

public interface IEntityState
{
    void Enter();

    void Update();

    void Exit();

    void AnimationFinishTrigger();
}
