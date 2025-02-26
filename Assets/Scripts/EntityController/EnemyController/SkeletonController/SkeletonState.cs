#nullable enable

namespace Game;

partial class SkeletonController
{
    partial class SkeletonStateMachine
    {
        protected abstract class SkeletonState : EnemyState
        {
            protected SkeletonState(SkeletonStateMachine skeletonStateMachine, string animationBoolName)
                : base(skeletonStateMachine, animationBoolName)
            {
                this.SkeletonStateMachine = skeletonStateMachine;
            }

            protected SkeletonStateMachine SkeletonStateMachine { get; }

            protected SkeletonController SkeletonController => this.SkeletonStateMachine.skeletonController;
        }
    }
}
