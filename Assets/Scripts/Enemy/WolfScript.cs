using UnityEngine;
using System;

namespace Game
{
    public class WolfScript:MonoBehaviour
    { 
        [SerializeField] private float speed;
        private int direction;
        private Rigidbody2D rigidBody2D;
        private Transform transform;
        private bool isMoving;
        [SerializeField] private Transform playerTransform;
        private int health;
        private bool isChasing;
        private Animator animator;
        private bool isDeath; 
        private bool isAttack;
        [SerializeField] private GameObject attackArea; 
        private float attackRange; 
        private bool isCallingHitFunction;
        
        void Start() {
            rigidBody2D= GetComponent<Rigidbody2D>(); 
            transform=GetComponent<Transform>(); 
            animator=GetComponent<Animator>();
            direction=0; 
            isMoving=true; 
            isChasing=false; 
            health=1000; 
            isDeath=false; 
            isAttack=false; 
            attackRange=1.6f; 
            isCallingHitFunction=false;
        } 
        private void Update() {
            float posPlayer=playerTransform.position.x;
            float posWolf=transform.position.x;
            if(Math.Abs(posPlayer-posWolf)<3.0f) {
                isChasing=true;
            } 
            else {
                isChasing=false;
            }
            HandleTakeDamage();  
            CheckHitPlayer();
            Death();
            
        }

        private void Move() { 
            if(rigidBody2D==null){
                return;
            } 
            if(isMoving==false) {
                return;
            }
            if(isChasing==true) {
                 float posPlayer=playerTransform.position.x;
                 float posWolf=transform.position.x;
                 float dir= posPlayer-posWolf; 
                 
                 if(dir<=0) { 
                    transform.position += new Vector3(-speed*Time.deltaTime,0,0);
                    direction=0;
                 } 
                 else {
                    transform.position += new Vector3(speed*Time.deltaTime,0,0);
                    direction=180;
                 } 
                ChangeDirection(direction);
                return;

            }
            if(direction==0) {
                transform.position += new Vector3(-speed*Time.deltaTime,0,0);
            }
            else {
                if(direction==180) {
                    transform.position += new Vector3(speed*Time.deltaTime,0,0);
                }
            }
        } 
        private void FixedUpdate() {
            Move();
        }
        private void OnCollisionEnter2D(Collision2D col) { 
            if(transform==null) {
                return;
            }
            if(col.gameObject.tag=="Border") {
                if(direction==0) {
                    direction=180;
                } 
                else {
                    direction=0;
                } 
                ChangeDirection(direction);
                

            }
        }
        public void updateMoving(bool newMoving) {
            this.isMoving= newMoving;
        } 
        private void OnTriggerEnter2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {
                isChasing=true;
                isMoving=false;
                Attack();
            } 
        } 
        private void OnTriggerExit2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {
                isChasing=false;
                isMoving=true;
                CancelInvoke("HitPlayer");
                StopAttack();
            }
        } 
        private void ChangeDirection(int direction) {
            Vector3 newDirection = new Vector3(transform.rotation.x,direction,transform.rotation.z);
            transform.rotation=Quaternion.Euler(newDirection);

        } 
         private void Attack() {
            if(animator==null) {
                return;
            } 
            isAttack=true; 
            
            animator.SetInteger("Atk",0);
        } 
        private void StopAttack() {
            if(animator==null) {
                return;
            } 
            isAttack=false; 
            isCallingHitFunction=false;
            animator.SetInteger("Atk",1);
        }
        private void HandleTakeDamage() {
            if(TakeDamage(100)) { 

                animator.SetTrigger("Take_Damage");
                isMoving=false;
                Invoke("LockMovingWhileTakingDamage",1f);
            }
        } 
        private bool TakeDamage(int damage) { 

            if(Input.GetKeyDown(KeyCode.Space)==true) { 
                health-=damage;
                return true;
            } 

            return false;
        }
        private void LockMovingWhileTakingDamage() {
            isMoving=true;
        } 
        private void Death() { 
            if(isDeath) {
                isMoving=false;
                isChasing=false;
            } 
            if(health<=0&&isDeath==false) {
            isMoving=false;
            isChasing=false;
            animator.SetInteger("Atk",2);
            animator.SetTrigger("Death");
            isDeath=true;
            }
        } 
        private void CheckHitPlayer() {
            
            if(attackArea==null||isAttack==false) {
                return;
            }  
            if(attackArea==null||attackArea.transform==null||attackArea.transform.position==null) {
                return;
            } 
            if(playerTransform==null||playerTransform.position==null) {
                return;
            }
            float distance = Vector3.Distance(attackArea.transform.position, playerTransform.position); 
            
            if(distance<=attackRange) {
                if(isCallingHitFunction==true) {
                    return;
                }
                else {
                isCallingHitFunction=true;
                InvokeRepeating("HitPlayer",0.5f,1f); 
                }
            }
            
        }
        private void HitPlayer() { 
            
            
            
            Debug.Log("Hit Player");
        }
        
    }
}
