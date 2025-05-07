using UnityEngine;

namespace Game
{
    public class DeathState : IState
    {
        public EnemyStateManager enemyStateManager {get;set;} 
        public DeathState(EnemyStateManager enemyStateManager) {
            this.enemyStateManager=enemyStateManager;
        } 
        public void Enter() {
            float deathPosY= enemyStateManager.GetDeathPosY();
            enemyStateManager.getAnimator().SetTrigger("Death");
            enemyStateManager.getAnimator().SetBool("IsDeath",true);
            enemyStateManager.GetSprite().localPosition = new Vector3(0,deathPosY,0);
            enemyStateManager.DestroyCanvas();
            enemyStateManager.Invoke("DestroyGameObject",enemyStateManager.GetTimeToDestroyAfterDeath());
        }
        public void Execute() {
            
        } 
        public void Exit() {
            
        }
    }
}
