using UnityEngine;

namespace Game
{
    public class AttackArea : MonoBehaviour
    {
        [SerializeField] private LayerMask layer;
        [SerializeField] private float attackRange;
        [SerializeField] private EnemyStateManager enemyStateManager;
        [SerializeField] private bool isChangeToAttackState;
        
        public void Awake() {
            this.enemyStateManager=GetComponent<EnemyStateManager>();
            this.isChangeToAttackState=false;
        }
        public void Update() {
            if(this.enemyStateManager.getCurrentState() is DeathState) {
               
                return;
            }
            Vector2 rayCastDir = new Vector2(1,0);
            if(enemyStateManager.getDirection()==0) {
                rayCastDir= new Vector2(-1,0);
            }
            RaycastHit2D hit = Physics2D.Raycast(transform.position+new Vector3(Vector2.left.x*0.5f,0,0), rayCastDir,attackRange,layer);
            

            if(hit.collider) {
                
                if(enemyStateManager.getCurrentState() is ChaseState &&!isChangeToAttackState) { 
                    
                    
                    this.enemyStateManager.ChangeState(new AttackState(this.enemyStateManager)); 
                    isChangeToAttackState=true;
                }
            }
            else {
                isChangeToAttackState=false;
            }
            

        }
        void OnDrawGizmos() {
            Gizmos.color=Color.red;
             Gizmos.DrawLine(transform.position+new Vector3(Vector2.left.x*0.5f,0,0), transform.position+Vector3.left*attackRange);
        }
    }
}
