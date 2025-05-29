using UnityEngine;
using System;
namespace Game
{
    public class EnemyStateManager : MonoBehaviour
    {
        [SerializeField] protected IState currentState;
        [SerializeField] protected IState previousState;
        [SerializeField] protected float moveSpeed;
        [SerializeField] protected float chaseSpeed;
        [SerializeField] protected float borderLeft;
        [SerializeField] protected float borderRight;
        [SerializeField] protected float direction;
        [SerializeField] protected Transform playerTransform;
        [SerializeField] protected Animator animator;
        [SerializeField] protected Rigidbody2D rg2D;
        [SerializeField] protected Vector2 forceDirection;
        [SerializeField] protected HealthController healthController;
        [SerializeField] protected float timeToDestroyAfterDeath;
        [SerializeField] protected Transform sprite;
        [SerializeField] protected float deathPosY;
        [SerializeField] protected int attackDamage;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected void Start()
        {
            this.currentState= new MoveState(this);
            this.previousState= new MoveState(this);
            this.currentState.Enter();
            this.healthController=GetComponent<HealthController>();
        }

        // Update is called once per frame
        protected void Update()
        {
            if(this.currentState is DeathState) {
                return;
            }
            this.currentState.Execute();
        } 
        public void ChangeState(IState newState) {
            if(this.currentState is DeathState||this.previousState is DeathState) {
                return;
            }
            this.currentState.Exit();
            this.previousState=this.currentState;
            this.currentState=newState;
            this.currentState.Enter();
        }
        public float getMoveSpeed() {
            return this.moveSpeed;
        } 
        public float getChaseSpeed() {
            return this.chaseSpeed;
        }
        public Transform getTransform() {
            return this.transform;
        }
        public float getBorderLeft() {
            return this.borderLeft;
        } 
        public float getBorederRight() {
            return this.borderRight;
        }
        public float getDirection() {
            return this.direction;
        } 
        public void setDirection(float direction) {
            this.direction=direction;
        }
        public Transform getPlayerTransform() {
            return this.playerTransform;
        } 
        public IState getCurrentState() {
            return this.currentState;
        }
        public void setPlayerTransform(Transform playerTransform) { 
            this.playerTransform=playerTransform;

        }
        public Animator getAnimator() {
            return this.animator;
        }
        public void BackToPreviousState() {
            ChangeState(previousState);
        }
        public IState getPreviousState() {
            return this.previousState;
        }
        public Rigidbody2D getRigidBody2D() {
            return this.rg2D;
        }
        public void TakeDamage() {
            if(this.currentState is DeathState||this.previousState is DeathState) {
                return;
            }
            
                if(!(this.currentState is DamageState)) {
                    ChangeState(new DamageState(this));
                }
            
        }
        public void setZ(float z) {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,z);

        }
        public void flipLeft() {
            this.transform.position+=new Vector3(-1,0,0);
        }
        public void flipRight() {
            this.transform.position+=new Vector3(1,0,0);
        }
        public void Teleport(Vector3 newPosition) {
            this.transform.position= newPosition;
        }
        public Vector2 GetForceDirection() {
            return this.forceDirection;
        }
        public HealthController GetHealthController() {
            return this.healthController;
        }
        public void DestroyGameObject() {
            Destroy(this.gameObject);
        }
        public float GetTimeToDestroyAfterDeath() {
            return this.timeToDestroyAfterDeath;
        }
        public Transform GetSprite() {
            return this.sprite;
        }
        public void DestroyCanvas() {
            Destroy(this.GetHealthController().GetCanvas());
        }
        public float GetDeathPosY() {
            return this.deathPosY;
        }
        public int GetAttackDamage() {
            return this.attackDamage;
        }
        
    }
}
