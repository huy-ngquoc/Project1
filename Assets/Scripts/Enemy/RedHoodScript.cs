using UnityEngine; 
using System;

namespace Game
{
    public class RedHoodScript:MonsterScript
    {  
        private bool isMoving; 
        private bool isSetShootTrigger;  
        private int redHoodState;
        [SerializeField] private int health;
        [SerializeField] private GameObject arrow;
        private void Start() { 
            transform = GetComponent<Transform>(); 
            animator=GetComponent<Animator>(); 
            isMoving=true; 
            isSetShootTrigger=false; 
            redHoodState=0;//1 hit //2 shoot

        } 
        private void Update() {
            DetectPlayer();  
            HandleTakeDamage();
            

        }       
        private void FixedUpdate() {   
            if(health<=0) {
                return;
            }
            
            if(!isMoving) { 

                return;
            }
            MonsterMove();
        } 
        private void DetectPlayer() { 
            if(playerTransform==null||transform==null) {
                return;
            }
            float posPlayer=playerTransform.position.x; 
            float posMonster=transform.position.x;
            float distance=posPlayer-posMonster;
            if(Math.Abs(distance)<=6.0f) {  
                
                ShootingRandom(); 
                
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
                isSetShootTrigger=false;
            }

        } 
        private void ShootingRandom() {  
            if(arrow==null) {
                return;
            }
            System.Random rand = new System.Random();
            int shootRandom= rand.Next(1,10);
            
            if(shootRandom<6&&isMoving&&isSetShootTrigger==false) { 
                isSetShootTrigger=true;
                animator.SetTrigger("ShootPlayer");
                Invoke("SpawnArrow",0.2f);
                
            } 
            else {
                
            }
        }
        private void SpawnArrow() {  
            if(arrow==null) {
                return;
            }
            int arrowDirection;
            if(direction==0) {
                arrowDirection=180;
            } 
            else {
                arrowDirection=0;
            }
            Vector3 arrowSpawnPosition= new Vector3(transform.position.x, transform.position.y-1,transform.position.z);
            Vector3 arrowSpawnRotation= new Vector3(transform.rotation.x, arrowDirection, transform.rotation.z); 
            Instantiate(arrow, arrowSpawnPosition,Quaternion.Euler(arrowSpawnRotation));

        }

        private void HandleTakeDamage() { 

            if(Input.GetKeyDown(KeyCode.Space)==true) { 
                TakeDamage(100); 
                
            }

        } 
        private void TakeDamage(int damage) {  
            if(animator==null) {
                return;
            }
            animator.SetTrigger("TakeDamage"); 
            health=health-damage;
            if(health<=0) {
                animator.SetTrigger("Death"); 
                isMoving=false;
            }

        }
        public void TriggerShooting() { 
            animator.SetTrigger("Shoot");

        } 
        public void StopMoving() { 
            isMoving=false;

        } 
        public void ContinueMoving() {
            isMoving=true;
        }
        public void ContinueMovingAniaton() {
            animator.SetTrigger("StopShoot");
        }
        public void ShootToHitAnimation() {
            animator.SetTrigger("ShootToHit");
        } 
        public void StopAttackAnimation() {
            animator.SetTrigger("StopAttack");
        } 
        public Transform getPlayerTransform() { 
            
            return playerTransform;
        }
        public Transform getRedHoodTransform() {
            return transform;
        } 
        private void BackToPreviousState() {

        }

        
    }
}
