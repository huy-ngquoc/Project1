using UnityEngine;

namespace Game
{
    public class AttackArea : MonoBehaviour
    {
        [SerializeField] private LayerMask layer;
        [SerializeField] private float attackRange;
        [SerializeField] private EnemyStateManager enemyStateManager;
        public void Awake() {
            this.enemyStateManager=GetComponent<EnemyStateManager>();
        }
        public void Update() {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left,attackRange,layer);
            

            if(hit.collider) {
                IState currentState = enemyStateManager.getCurrentState();
                if(currentState is ChaseState) { 
                    
                   
                    this.enemyStateManager.ChangeState(new AttackState(this.enemyStateManager));
                }
            }
            else {
                IState currentState = enemyStateManager.getCurrentState();
                if(currentState is AttackState) {
                    this.enemyStateManager.BackToPreviousState();
                }
            }

        }
    }
}
