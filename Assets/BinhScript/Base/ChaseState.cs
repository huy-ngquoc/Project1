using UnityEngine;

namespace Game
{
    public class ChaseState:IState
    {
        public EnemyStateManager enemyStateManager {get;set;}
        private float chaseSpeed;
        private float borderLeft;
        private float borderRight;
        private Transform enemyTransform;
        private Transform playerTransform;
        private float direction;
        public ChaseState(EnemyStateManager enemyStateManager) {
            this.enemyStateManager=enemyStateManager;
        }
        public void Enter() {
            this.chaseSpeed=enemyStateManager.getChaseSpeed();
            this.borderLeft=enemyStateManager.getBorderLeft();
            this.borderRight=enemyStateManager.getBorederRight();
            this.enemyTransform=enemyStateManager.getTransform();
            this.playerTransform=enemyStateManager.getPlayerTransform();
            this.direction= enemyStateManager.getDirection();
        } 
        public void Execute() {
            float currentPos = this.enemyTransform.position.x;
            float playerPos= this.playerTransform.position.x;
            if(currentPos<borderLeft||currentPos>borderRight) {
                enemyStateManager.ChangeState(new MoveState(enemyStateManager));
            } 
            if(currentPos>playerPos) {
                this.direction=0;
                enemyStateManager.setDirection(0);
                this.enemyTransform.rotation=Quaternion.Euler(0,0,0);
            } 
            else {
                 this.direction=1;
                enemyStateManager.setDirection(1);
                this.enemyTransform.rotation=Quaternion.Euler(0,180,0);
            }
            this.enemyTransform.Translate(Vector2.left*chaseSpeed*Time.deltaTime);
            
        } 
        public void Exit() {

        }
    }
}
