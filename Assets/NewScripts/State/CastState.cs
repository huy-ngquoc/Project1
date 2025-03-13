using UnityEngine;

namespace Game
{
    public class CastState:IState
    {
        public EnemyStateManager enemyStateManager {get;set;} 
        public CastState() {

        } 
        public CastState(EnemyStateManager enemyStateManager) {
            this.enemyStateManager=enemyStateManager;
        }
        public void Enter() {
            this.enemyStateManager.GetAnimator().SetTrigger("Cast"); 

            this.enemyStateManager.Invoke("Teleport",0.8f);
        } 
        public void Execute() {

        }
        public void Exit() {

        }
    }
}
