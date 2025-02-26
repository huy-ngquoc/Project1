using UnityEngine;
using System;
namespace Game
{
    public class SlimeScript:MonsterScript
    { 
        private bool isMoving; 
        private int health;
        private void Start() {
            transform = GetComponent<Transform>(); 
            isMoving=true; 
            animator=GetComponent<Animator>(); 
            health=1000;
        } 
        private void FixedUpdate() { 
            if(!isMoving) {
                return;
            } 
            if(health<=0) {
                return;
            }
            MonsterMove();
        } 
        private void Update() { 
            if(health<=0) {
                return;
            }
            DetectPlayer();
            HandleTakeDamage(); 
            HandleDeath();
        }
        private void DetectPlayer() {
            if(playerTransform==null||transform==null) {
                return;
            }
            float posPlayer=playerTransform.position.x; 
            float posMonster=transform.position.x;
            float distance=posPlayer-posMonster;
            if(Math.Abs(distance)<=6.0f) {  
                
                 
                
                if(distance<0) {
                    direction=0; 
                    ChangeDirection(); 
                    
                } 
                else {
                    direction=180; 
                    
                    ChangeDirection();
                }
            } 
            else {
                
            }
        }  
        private void HandleTakeDamage() {
            if(animator==null) {
                return;
            }
            if(Input.GetKeyDown(KeyCode.Space)==true) {
                animator.SetTrigger("TakeDamage");  
                health-=100;
                
                Invoke("BackToPreviousState",0.3f);
            }
        }  
        private void HandleDeath() {
            if(health<=0) {
                animator.SetTrigger("Death");
                isMoving=false;
            }
        }
        private void BackToPreviousState() {
            if(isMoving==false&&health>0) {
                animator.SetTrigger("Attack");
            } 
            else if(health>0) {
                animator.SetTrigger("Move");
            } 
            else {
                animator.SetTrigger("Death");
            }
        }
        public Transform getTransform() {
            return transform;
        } 
        public Transform getPlayerTransform() {
            return playerTransform;
        }
        public void setIsMoving(bool newIsMoving) { 
            isMoving=newIsMoving;
            
        }
        public Animator getAnimator() {
            return this.animator;
        }  
        public int getHealth() {
            return health;
        }
    }
}
