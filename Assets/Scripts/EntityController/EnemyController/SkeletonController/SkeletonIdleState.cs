#nullable enable

namespace Game;

partial class SkeletonController
{
    partial class SkeletonStateMachine
    {
        private sealed class SkeletonIdleState : SkeletonGroundedState
        {
            public SkeletonIdleState(SkeletonStateMachine skeletonStateMachine, string animationBoolName)
                : base(skeletonStateMachine, animationBoolName)
            {
            }
        }
    }
}
