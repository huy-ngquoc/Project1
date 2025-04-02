using UnityEngine;
using System;
namespace Game
{
    public class AnimationScript : MonoBehaviour
    {
        public Animator anim;
        [SerializeField] protected LayerMask layer;
        [SerializeField] protected Vector3 attackOffset;
        [SerializeField] protected float attackRange;
        [SerializeField] protected EnemyStateManager enemyStateManager;
        [SerializeField] protected Vector2 forceDirection;
        
        public void Attack() {
            Transform currentTransform = enemyStateManager.getTransform();
            if(enemyStateManager.getDirection()==1) {
                attackOffset.x=-Math.Abs(attackOffset.x);
            } 
            else {
                attackOffset.x=Math.Abs(attackOffset.x);
            }
            Vector2 attackPosition = new Vector2(currentTransform.position.x+attackOffset.x, currentTransform.position.y+attackOffset.y);
            Collider2D[] col = Physics2D.OverlapCircleAll(attackPosition,attackRange,layer);
            foreach(Collider2D i in col) {
                if(i.gameObject.TryGetComponent<EntityStats>(out var entityStats)) {
                    entityStats.TakeDamage();
                }
            }
        }
        public void EndDamageAnimation() {
            
            enemyStateManager.ChangeState(new ChaseState(enemyStateManager));

        }
        public void AddForceWhenTakeDamage() {
            Transform playerTransform = enemyStateManager.getPlayerTransform();
           
            if(playerTransform.position.x>transform.position.x) {
                forceDirection.x=-Math.Abs(forceDirection.x);
            }
            else {
                forceDirection.x=Math.Abs(forceDirection.x);
            }
            enemyStateManager.getRigidBody2D().AddForce(forceDirection, ForceMode2D.Impulse);
        }
        public void HandleEndAttack() {
             if(enemyStateManager.getDirection()==1) {
                attackOffset.x=-Math.Abs(attackOffset.x);
            } 
            else {
                attackOffset.x=Math.Abs(attackOffset.x);
            }
            Transform currentTransform = enemyStateManager.getTransform();
            Vector2 attackPosition = new Vector2(currentTransform.position.x+attackOffset.x, currentTransform.position.y+attackOffset.y);
            Collider2D[] col = Physics2D.OverlapCircleAll(attackPosition,attackRange,layer);
            
            if(col.Length==0) {
                
                enemyStateManager.ChangeState(new ChaseState(enemyStateManager));
                enemyStateManager.setZ(0);
            }
        }

        public void StartAttack() {
            enemyStateManager.setZ(1);
        }

        
         
    }
}
