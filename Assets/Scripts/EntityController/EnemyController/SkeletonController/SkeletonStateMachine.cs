#nullable enable

namespace Game;

partial class SkeletonController
{
    partial class SkeletonStateMachine : EnemyStateMachine
    {
        private readonly SkeletonController skeletonController;

        public SkeletonStateMachine(SkeletonController skeletonController)
            : base(skeletonController)
        {
            this.skeletonController = skeletonController;
        }
    }
}
