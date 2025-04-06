using UnityEngine;

namespace Game
{
    public interface IState
    {
        public EnemyStateManager enemyStateManager {get;set;}
        public void Enter();
        public void Execute();
        public void Exit();
    }
}
