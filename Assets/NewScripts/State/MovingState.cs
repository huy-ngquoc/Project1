using UnityEngine;

namespace Game
{
    public class MovingState:IState
    { 
        public EnemyStateManager enemyStateManager {get;set;}
        public MovingState() {

        } 
        public MovingState(EnemyStateManager enemyStateManager) {
            this.enemyStateManager=enemyStateManager;
        }
        public void Enter() {
            this.enemyStateManager.GetAnimator().SetTrigger("Move");
        } 
        public void Execute() {
            Transform monsterTransform= this.enemyStateManager.GetTransform();
            if(monsterTransform.position.x<=this.enemyStateManager.GetLeftBorder()) {
                this.enemyStateManager.SetDirection(180); 
                this.enemyStateManager.SetRotation();
            } 
            if(monsterTransform.position.x>=this.enemyStateManager.GetRightBorder()) {
                this.enemyStateManager.SetDirection(0); 
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
