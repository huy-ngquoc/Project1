using UnityEngine;

namespace Game
{
    public class CastState:IState
    {
        public EnemyStateManager enemyStateManager {get;set;} 
        public CastState(EnemyStateManager enemyStateManager) {
            this.enemyStateManager= enemyStateManager;
        } 
        public void Enter() {
            enemyStateManager.getAnimator().SetTrigger("Cast");
        } 
        public void Execute() {

        } 
        public void Exit() {
            
        }
    }
}
