#nullable enable

namespace Game;

partial class EnemyController
{
    partial class EnemyStateMachine
    {
        protected abstract class EnemyState : EntityState
        {
            protected EnemyState(EnemyStateMachine enemyStateMachine, string animationBoolName)
                : base(enemyStateMachine, animationBoolName)
            {
                this.EnemyStateMachine = enemyStateMachine;
            }

            protected EnemyStateMachine EnemyStateMachine { get; }

            protected EnemyController EnemyController => this.EnemyStateMachine.enemyController;
        }
    }
}
