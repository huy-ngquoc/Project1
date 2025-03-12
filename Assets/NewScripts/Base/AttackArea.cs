using UnityEngine;

namespace Game
{
    public class AttackArea : MonoBehaviour
    {
        [SerializeField] protected EnemyStateManager enemyStateManager;

        protected virtual void OnTriggerEnter2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {
                enemyStateManager.ChangeState(new AttackState(enemyStateManager));
            }
        } 
        protected virtual void OnTriggerExit2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {
                enemyStateManager.ChangeState(new MovingState(enemyStateManager));
            }
        } 
       
    }
}
