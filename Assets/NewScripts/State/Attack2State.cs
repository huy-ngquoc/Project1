using UnityEngine;

namespace Game
{
    public class Attack2State:IState
    {
        public EnemyStateManager enemyStateManager {get;set;} 
        public Attack2State() {

        } 
        public Attack2State(EnemyStateManager enemyStateManager) {
            this.enemyStateManager=enemyStateManager;
        }
        public void Enter() { 
            this.enemyStateManager.GetAnimator().SetTrigger("Attack2");
            this.enemyStateManager.Invoke("Attack2Player",0.15f);
        } 
        public void Execute() {

        }
        public void Exit() {

        }
    }
}
