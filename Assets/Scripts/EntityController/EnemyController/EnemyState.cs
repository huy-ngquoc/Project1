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

            protected sealed override void OnEntityStateEnter()
            {
                this.OnEnemyStateEnter();
            }

            protected virtual void OnEnemyStateEnter()
            {
                // Leave this method blank
                // The derived classes can decide if they override this method
            }

            protected sealed override void OnEntityStateUpdate()
            {
                this.OnEnemyStateUpdate();
            }

            protected virtual void OnEnemyStateUpdate()
            {
                // Leave this method blank
                // The derived classes can decide if they override this method
            }

            protected sealed override void OnEntityStateExit()
            {
                this.OnEnemyStateExit();
            }

            protected virtual void OnEnemyStateExit()
            {
                // Leave this method blank
                // The derived classes can decide if they override this method
            }
        }
    }
}
