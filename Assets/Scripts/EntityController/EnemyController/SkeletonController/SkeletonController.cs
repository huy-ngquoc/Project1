#nullable enable

namespace Game
{
    public sealed partial class SkeletonController : EnemyController
    {
        private SkeletonStateMachine? skeletonStateMachine;

        protected override void OnEnemyControllerAwake()
        {
            this.skeletonStateMachine = new SkeletonStateMachine(this);
        }

        protected override void OnEnemyControllerUpdate()
        {
            this.skeletonStateMachine?.UpdateState();
        }
    }
}
