using UnityEngine;

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
    }
}
