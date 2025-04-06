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
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        protected void Start()
        {
            this.currentState= new MoveState(this);
            this.previousState= new MoveState(this);
            this.currentState.Enter();
        }

        // Update is called once per frame
        protected void Update()
        {
            this.currentState.Execute();
        } 
        public void ChangeState(IState newState) {
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
            float distance = System.Math.Abs(playerTransform.position.x-transform.position.x);
            if(distance<2) {
                if(!(this.currentState is DamageState)) {
                    ChangeState(new DamageState(this));
                }
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
        
    }
}
