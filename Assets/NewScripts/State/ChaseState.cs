using UnityEngine;

namespace Game
{
    public class ChaseState:IState
    {
        public EnemyStateManager enemyStateManager {get;set;} 
        public ChaseState() {
            
        } 
        public ChaseState(EnemyStateManager enemyStateManager) {
            this.enemyStateManager=enemyStateManager;
        } 
        public void Enter() {
            this.enemyStateManager.GetAnimator().SetTrigger("Move");
        } 
        public void Execute() {
            Transform playerTransform = enemyStateManager.GetPlayerTransform();
            Transform monsterTransform = enemyStateManager.GetTransform();
            if(playerTransform==null) {
                return;
            } 
            if(playerTransform.position.x<=monsterTransform.position.x) {
                this.enemyStateManager.SetDirection(0); 
                this.enemyStateManager.SetRotation();
            } 
            else {
                this.enemyStateManager.SetDirection(180); 
                this.enemyStateManager.SetRotation();
            }
            Vector3 moveVelocity = new Vector3(this.enemyStateManager.GetMoveSpeed()*Time.deltaTime,0,0);
            if(this.enemyStateManager.GetDirection()==0) {
                this.enemyStateManager.Move(-moveVelocity);
            } 
            else {
                this.enemyStateManager.Move(moveVelocity);
            }
        } 
        public void Exit() {

        }
    }
}
