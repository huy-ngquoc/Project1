#nullable enable

namespace Game;

public sealed class SkeletonIdleState : SkeletonGroundedState
{
    public SkeletonIdleState(SkeletonStateMachine skeletonStateMachine)
    {
        this.SkeletonStateMachine = skeletonStateMachine;
    }

    public override string AnimationBoolName => AnimationBoolNameConstants.Idle;

    protected override SkeletonStateMachine SkeletonStateMachine { get; }
}
