using UnityEngine;

namespace Game
{
    public class MoveState:IState
    {
        public EnemyStateManager enemyStateManager {get;set;} 
        private float moveSpeed;
        private Transform enemyTransform;
        private float borderLeft;
        private float borderRight;
        private float direction;
        public MoveState(EnemyStateManager enemyStateManager) { 
            this.enemyStateManager=enemyStateManager;
            
        }
        public void Enter() {
            this.moveSpeed=enemyStateManager.getMoveSpeed();
            this.enemyTransform=enemyStateManager.getTransform();
            this.borderLeft=enemyStateManager.getBorderLeft();
            this.borderRight=enemyStateManager.getBorederRight();
            this.direction=enemyStateManager.getDirection();
        } 
        public void Execute() {
            
            this.enemyTransform.Translate(Vector2.left*moveSpeed*Time.deltaTime);
            
            if(this.enemyTransform.position.x<borderLeft) {
                this.direction=1;
                enemyStateManager.setDirection(1);
                this.enemyTransform.rotation=Quaternion.Euler(0,180,0);
            } 
            if(this.enemyTransform.position.x>borderRight) {
                this.direction=0;
                enemyStateManager.setDirection(0);
                this.enemyTransform.rotation=Quaternion.Euler(0,0,0);
            }
        } 
        public void Exit() {

        }
    }
}
