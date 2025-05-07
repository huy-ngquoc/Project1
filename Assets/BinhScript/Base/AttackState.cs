using UnityEngine;

namespace Game
{
    public class AttackState : IState
    {
       public EnemyStateManager enemyStateManager {get;set;}
       public AttackState(EnemyStateManager enemyStateManager) {
            
            this.enemyStateManager=enemyStateManager;
            
            
       }
       public void Enter() {
            if(this.enemyStateManager.getPreviousState() is DeathState) {
               Debug.Log("Death");
               return;
            }
            if(this.enemyStateManager.GetHealthController().GetCurrentHealth()<=0) {
               Debug.Log(this.enemyStateManager.GetHealthController().GetCurrentHealth());
               return;
            }
            Debug.Log(this.enemyStateManager.GetHealthController().GetCurrentHealth());
            Debug.Log("Trigger attack");
            enemyStateManager.getAnimator().SetTrigger("Attack");
            
       }        
       public void Execute() {

       } 
       public void Exit() {
     
       }

    }
}
