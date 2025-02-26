#nullable enable

namespace Game;

partial class EnemyController : EntityController
{
    protected partial class EnemyStateMachine : EntityStateMachine
    {
        private readonly EnemyController enemyController;

        public EnemyStateMachine(EnemyController enemyController)
            : base(enemyController)
        {
            this.enemyController = enemyController;
        }
    }
}
