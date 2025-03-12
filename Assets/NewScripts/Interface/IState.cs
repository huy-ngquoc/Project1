using UnityEngine;

namespace Game
{
    public interface IState
    {
        EnemyStateManager enemyStateManager {get;set;}
        public void Enter();
        public void Execute();
        public void Exit();
    }
}
