using UnityEngine;
using System;
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
            
            this.direction= enemyStateManager.getDirection();
            this.enemyStateManager.getAnimator().SetTrigger("Move");
            
            
        } 
        public void Execute() {
            this.playerTransform=enemyStateManager.getPlayerTransform();
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
            if(playerTransform!=null) {
                float distance = Math.Abs(playerTransform.position.x-enemyTransform.position.x);
                if(distance<=0.1f) {
                    if(direction==0) {
                        this.enemyStateManager.flipLeft();
                    } 
                    else {
                        this.enemyStateManager.flipRight();
                    }
                }
                distance=Math.Abs(playerTransform.position.y-enemyTransform.position.y);
                if(distance>=3) {
                    this.enemyStateManager.ChangeState(new MoveState(this.enemyStateManager));
                }
            }
            
            
        } 
        public void Exit() {
            
        }
    }
}
