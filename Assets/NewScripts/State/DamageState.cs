using UnityEngine;

namespace Game
{
    public class DamageState:IState
    {
         public EnemyStateManager enemyStateManager {get;set;}

         public DamageState() {

         } 
         public DamageState(EnemyStateManager enemyStateManager) { 
            this.enemyStateManager=enemyStateManager;
         }
         public void Enter() {
            enemyStateManager.GetAnimator().SetTrigger("Damage"); 
            enemyStateManager.Invoke("BackToPreviousState",this.enemyStateManager.GetTakeDamageTime());
         } 
         public void Execute() {

         } 
         public void Exit() {

         }
    }
}
