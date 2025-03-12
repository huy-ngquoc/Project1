using UnityEngine;

namespace Game
{
    public class AttackState:IState
    { 
        public EnemyStateManager enemyStateManager {get;set;}
        public  AttackState(EnemyStateManager enemyStateManager) {
            this.enemyStateManager=enemyStateManager;
        }
        public void Enter() { 
            this.enemyStateManager.GetAnimator().SetTrigger("Attack");
            enemyStateManager.InvokeRepeating("AttackPlayer",this.enemyStateManager.GetTimeToAttack(),this.enemyStateManager.GetAttackInvokeTime());
        } 
        public void Execute() {
        } 
        public void Exit() {
            enemyStateManager.CancelInvoke("AttackPlayer");
        } 
        
    }
}
