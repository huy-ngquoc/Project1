using UnityEngine;

namespace Game
{
    public class Attack2Area : MonoBehaviour
    {
        [SerializeField] protected EnemyStateManager enemyStateManager; 
        
        protected virtual void OnTriggerEnter2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {
                enemyStateManager.ChangeState(new Attack2State(enemyStateManager)); 
            }
        }
    }
}
