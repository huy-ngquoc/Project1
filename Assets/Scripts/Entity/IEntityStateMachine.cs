#nullable enable

namespace Game;

public interface IEntityStateMachine : IEntityState
{
    bool HasStateToChangeTo();

    void SetStateToChangeTo(IEntityState newState);

    void AnimationFinishTrigger();
}
