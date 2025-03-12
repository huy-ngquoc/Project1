using UnityEngine;

namespace Game
{
    public class DetectArea : MonoBehaviour
    { 
        [SerializeField] protected EnemyStateManager enemyStateManager;
        protected virtual void OnTriggerEnter2D(Collider2D col) {
            if(col.gameObject.tag=="Player"){
                enemyStateManager.ChangeState(new ChaseState(enemyStateManager));
            }
        }
        protected virtual void OnTriggerExit2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {
                enemyStateManager.ChangeState(new MovingState(enemyStateManager));
            }
        }
    }
}
