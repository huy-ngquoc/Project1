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
            enemyStateManager.getAnimator().SetTrigger("Attack");
         
          
       }        
       public void Execute() {

       } 
       public void Exit() {
        
       }

    }
}
