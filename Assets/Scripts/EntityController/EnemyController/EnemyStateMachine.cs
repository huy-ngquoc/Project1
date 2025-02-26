#nullable enable

namespace Game;

partial class EnemyController : EntityController
{
    protected abstract partial class EnemyStateMachine : EntityStateMachine
    {
        private readonly EnemyController enemyController;

        protected EnemyStateMachine(EnemyController enemyController)
            : base(enemyController)
        {
            this.enemyController = enemyController;
        }
    }
}
