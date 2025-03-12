using UnityEngine;

namespace Game
{
    public class DeathState:IState
    {
        public EnemyStateManager enemyStateManager {get;set;}  
        public DeathState() {

        } 
        public DeathState(EnemyStateManager enemyStateManager) {
            this.enemyStateManager=enemyStateManager;
        }
        public void Enter() {
            this.enemyStateManager.GetAnimator().SetTrigger("Death");

        } 
        public void Execute() {

        } 
        public void Exit() {

        }
    }
}
