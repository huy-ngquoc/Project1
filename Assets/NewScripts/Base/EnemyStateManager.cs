using UnityEngine;

namespace Game
{
    public class EnemyStateManager : MonoBehaviour
    {
        [SerializeField] protected IState currentState; 
        [SerializeField] protected IState previouState;
        [SerializeField] protected Transform transform;
        [SerializeField] protected int direction;
        [SerializeField] protected float leftBorder;
        [SerializeField] protected float rightBorder;
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected Animator animator; 
        [SerializeField] protected float currentHealth;
        [SerializeField] protected float maxHealth;
        [SerializeField] protected Transform playerTransform;
        [SerializeField] protected float timeToAttack;
        [SerializeField] protected float attackInvokeTime;
        [SerializeField] protected float takeDamageTime;
        protected void Awake() {
            currentState= new MovingState(this); 
            previouState= new MovingState(this);
            transform=this.GetComponent<Transform>();
            moveSpeed=2; 
        }

        protected void Update() {
            if(Input.GetKeyDown(KeyCode.Space)) {
                
                HandleTakeDamage(500);
            }
            if(currentState!=null) {
                currentState.Execute();
            }
        }  
        public float GetTimeToAttack() {
            return this.timeToAttack;
        } 
        public float GetAttackInvokeTime() {
            return this.attackInvokeTime;
        }
        public float GetTakeDamageTime() {
            return this.takeDamageTime;
        } 
        public Transform GetTransform() {
            return this.transform;
        } 
        public void Move(Vector3 velocity) {
            this.transform.position+=velocity;
        }
        public void SetRotation() {
            if(this.direction==0) {
                transform.rotation=Quaternion.Euler(0,0,0);
            } 
            else {
                transform.rotation=Quaternion.Euler(0,180,0);
            }
        } 
        public int GetDirection() {
            return this.direction;
        } 
        public void SetDirection(int direction) {
            this.direction=direction;
        } 
        public float GetMoveSpeed() {
            return this.moveSpeed;
        }
        public float GetLeftBorder() {
            return this.leftBorder;
        } 
        public float GetRightBorder() {
            return this.rightBorder;
        }  
        public Animator GetAnimator() {
            return this.animator;
        } 
        public Transform GetPlayerTransform() {
            return this.playerTransform;
        }
        public void ChangeState(IState newState) {
            if(newState==null) {
                return;
            } 
            if(this.currentState!=null) {
                if(newState.GetType()==this.currentState.GetType()) {
                    return;
                } 
                this.previouState=this.currentState;
                this.currentState.Exit();
                this.currentState=newState;
                this.currentState.Enter();
            }
        } 
        protected void AttackPlayer() {
            Debug.Log("Hit player");
        } 
        public void BackToPreviousState() {
            ChangeState(this.previouState);
        } 
        public void HandleTakeDamage(float damage) {
            this.currentHealth-=damage;
            if(this.currentHealth<=0) {
               this.ChangeState(new DeathState(this));  
            } 
            else {
                this.ChangeState(new DamageState(this));
            }
        }
    }
}
