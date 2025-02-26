#nullable enable

namespace Game;

partial class SkeletonController
{
    private sealed partial class SkeletonStateMachine : EnemyStateMachine
    {
        private readonly SkeletonController skeletonController;
        private readonly SkeletonIdleState skeletonIdleState;

        public SkeletonStateMachine(SkeletonController skeletonController)
            : base(skeletonController)
        {
            this.skeletonController = skeletonController;
            this.skeletonIdleState = new SkeletonIdleState(this, "Idle");

            this.ChangeState(this.skeletonIdleState);
        }
    }
}
