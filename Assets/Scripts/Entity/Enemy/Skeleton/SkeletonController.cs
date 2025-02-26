#nullable enable

namespace Game
{
    public sealed class SkeletonController : EnemyController
    {
        protected override void OnEnemyControllerAwake()
        {
            this.StateMachine = new SkeletonStateMachine(this);
        }
    }
}
