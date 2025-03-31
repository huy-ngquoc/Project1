using UnityEngine;

namespace Game
{
    public class AnimationScript : MonoBehaviour
    {
        public Animator anim;
        [SerializeField] protected LayerMask layer;
        [SerializeField] protected Vector3 attackOffset;
        [SerializeField] protected float attackRange;
        [SerializeField] protected EnemyStateManager enemyStateManager;
        public void Attack() {
            Vector2 attackPosition = new Vector2(transform.position.x+attackOffset.x, transform.position.y+attackOffset.y);
            Collider2D[] col = Physics2D.OverlapCircleAll(attackPosition,attackRange,layer);
            foreach(Collider2D i in col) {
                Debug.Log("Hit player");
            }
        }
        public void EndDamageAnimation() {
            
            enemyStateManager.BackToPreviousState();
        }
    }
}
