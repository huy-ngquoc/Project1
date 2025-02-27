#nullable enable

namespace Game
{
    public sealed class SkeletonStateMachine : EnemyStateMachine
    {
        public SkeletonStateMachine()
        {
            this.SkeletonIdleState = new SkeletonIdleState(this, "Idle");

            this.SetStateToChangeTo(this.SkeletonIdleState);
        }

        public SkeletonController? SkeletonController { get; private set; }

        public SkeletonIdleState SkeletonIdleState { get; }

        protected override void OnEnemyStateMachineValidate()
        {
            this.SkeletonController = (SkeletonController?)this.EnemyController;
        }
    }
}
