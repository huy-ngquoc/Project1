#nullable enable

namespace Game;

public sealed class SkeletonIdleState : SkeletonGroundedState
{
    public SkeletonIdleState(SkeletonStateMachine skeletonStateMachine, string animationBoolName)
        : base(skeletonStateMachine, animationBoolName)
    {
    }
}
