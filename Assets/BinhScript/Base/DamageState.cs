using UnityEngine;

namespace Game
{
    public class DamageState : IState
    {
        public EnemyStateManager enemyStateManager {get;set;}
        public DamageState(EnemyStateManager enemyStateManager) { 
            this.enemyStateManager=enemyStateManager;
        } 
        public void Enter() {
            this.enemyStateManager.getAnimator().SetTrigger("Damage");
            
        }
        public void Execute() {

        } 
        public void Exit() {

        }
    }
}
