using UnityEngine;
using System; 
using Game;

namespace Game
{
    public class MonsterScript:MonoBehaviour
    {   
        [SerializeField] protected Rigidbody2D rigidBody; 
        [SerializeField] protected Transform transform;  
        [SerializeField] protected Transform attackArea; 
        [SerializeField] protected Animator animator;
        [SerializeField] protected State currentState;
        [SerializeField] protected State previousState;
        [SerializeField] protected float takeDamageTime; 
        [SerializeField] protected int direction; 
        [SerializeField] protected float speed; 
        [SerializeField] protected Transform player; 
        [SerializeField] protected int health;
        protected virtual void Start() {
            rigidBody=GetComponent<Rigidbody2D>(); 
            transform = GetComponent<Transform>();
            attackArea=transform.Find("AttackArea");  
            animator=GetComponent<Animator>();
            currentState=State.move;
            previousState=State.idle;  
            AnimationControl();
            takeDamageTime=0.8f; 
            direction=0; 
            speed=1.0f; 
            health=1000;
        }
        protected virtual void MonsterMove() {

        }  
        protected virtual void FixedUpdate() { 
            if(currentState==State.move) {
                Move(); 
            } 
            else if(currentState==State.chase) {
                Chase();
            }
            
        }
        protected virtual void Update() {
            HandleTakeDamage(500);
        }
        public virtual void AnimationControl() {
            animator.SetBool(GetStateString(currentState),true);
            animator.SetBool(GetStateString(previousState),false);
        } 
        public virtual void SetState(State state) { 
            previousState=currentState; 
            currentState=state;
        }        
        private string GetStateString(State state) { 
            if(state==State.idle) {
                return "IsIdle";
            } 
            if(state==State.move||state==State.chase) {
                return "IsMoving";
            } 
            if(state==State.attack1) {
                return "IsAttack1";
            }  
            if(state==State.attack2) {
                return "IsAttack2";
            }
            if(state==State.takeDamage) {
                return "IsDamage";
            } 
            if(state==State.death) {
                return "IsDeath";
            }
            return "";

        }
        protected virtual bool TakeDamage() {
            return Input.GetKeyDown(KeyCode.Space)&&health>0;
        } 
        protected virtual void HandleTakeDamage(int damage) { 
            if(TakeDamage()) {
                SetState(State.takeDamage);
                AnimationControl();  
                health-=damage;
                if(health<=0) {
                    SetState(State.death);
                    AnimationControl();  
                    animator.SetTrigger("Death");
                    return;
                }
                Invoke("BackToPreviousState",takeDamageTime); 
                
            } 
            
        } 
        protected virtual void BackToPreviousState() {
            State previous=previousState;
            previousState=currentState;
            currentState=previous; 
            AnimationControl();
        } 
        protected virtual void Move() {  
            if(direction==0) {
                transform.position+=new Vector3(-speed*Time.deltaTime,0,0);
            } 
            else {
                transform.position+=new Vector3(speed*Time.deltaTime,0,0);
            }


        }
        protected virtual void OnCollisionEnter2D(Collision2D col) {
            if(col.gameObject.tag=="Border") { 
                
                if(direction==0) {
                    direction=180;
                } 
                else direction=0;
                ChangeDirection();

            }
        } 
        protected virtual void ChangeDirection() {
            Vector3 newDir = new Vector3(0,direction,0);
             
            transform.rotation=Quaternion.Euler(newDir);
        } 
        protected virtual void Chase() {
            float directionToPlayer=transform.position.x-player.position.x;
            if(directionToPlayer<=0) {
                direction=180;
                
            } 
            else { 
                direction=0;
            } 
            ChangeDirection();
            Move();
        } 
        public virtual int GetDirection() {
            return direction;
        } 
        public virtual State GetState() {
            return currentState;
        }
       
    } 
    
}
