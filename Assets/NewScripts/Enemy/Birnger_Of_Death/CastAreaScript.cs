using UnityEngine;

namespace Game
{
    public class CastAreaScript : MonoBehaviour
    {
        [SerializeField] protected EnemyStateManager enemyStateManager;
        protected virtual void OnTriggerEnter2D(Collider2D col) {
            if(col.gameObject.tag=="Player") 
            {
                this.enemyStateManager.ChangeState(new CastState(this.enemyStateManager));
            }
        }
    }
}
