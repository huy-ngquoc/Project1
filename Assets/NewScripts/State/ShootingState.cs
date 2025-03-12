using UnityEngine;

namespace Game
{
    public class ShootingState:IState
    {
        public EnemyStateManager enemyStateManager {get;set;} 
        public ShootingState() {

        } 
        public ShootingState(EnemyStateManager enemyStateManager) {
            this.enemyStateManager=enemyStateManager;
        } 
        public void Enter() {
            this.enemyStateManager.GetAnimator().SetTrigger("Shoot");
            this.enemyStateManager.Invoke("BackToPreviousState",0.5f);
        } 
        public void Execute() {

        } 
        public void Exit() {

        }
    }
}
