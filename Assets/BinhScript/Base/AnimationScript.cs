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
        [SerializeField] protected float teleportOffSet;
        [SerializeField] protected HealthController healthController;
        [SerializeField] protected int[] clipIndex; //clipIndex[0]: attack, clipIndex[1]: death, clipIndex[2]: cast (bringer of death)
        public void Awake() {
            
        }
        public void Attack() {
            Transform currentTransform = enemyStateManager.getTransform();
            
            if(enemyStateManager.getDirection()==1) {
                attackOffset.x=Math.Abs(attackOffset.x);
            } 
            else {
                attackOffset.x=-Math.Abs(attackOffset.x);
            }
            Vector2 attackPosition = new Vector2(currentTransform.position.x+attackOffset.x, currentTransform.position.y+attackOffset.y);
            Collider2D[] col = Physics2D.OverlapCircleAll(attackPosition,attackRange,layer);
            foreach(Collider2D i in col) {
                
                Vector2 fDir = enemyStateManager.GetForceDirection();
                if(i.gameObject.TryGetComponent<HandlePlayerTakeDamage> ( out var playerHandleTakeDamage)) {
                    
                    playerHandleTakeDamage.TakeDamage(fDir, enemyStateManager.getTransform());
                }
                if(!(enemyStateManager.getCurrentState() is AttackState)) 
                {
                    enemyStateManager.ChangeState(new AttackState(enemyStateManager));
                    return;
                }
            }
        }
        public void EndDamageAnimation() {
            if(enemyStateManager.getCurrentState() is DeathState) {
                return;
            }
            enemyStateManager.ChangeState(new ChaseState(enemyStateManager));

        }
        public void AddForceWhenTakeDamage() {
            Transform playerTransform = enemyStateManager.getPlayerTransform();
            Transform currentTransform = enemyStateManager.getTransform();
            if(playerTransform.position.x>currentTransform.position.x) {
                forceDirection.x=-Math.Abs(forceDirection.x);
            }
            else {
                forceDirection.x=Math.Abs(forceDirection.x);
            }

            enemyStateManager.getRigidBody2D().AddForce(forceDirection, ForceMode2D.Impulse);
        }
        public void HandleEndAttack() {
            if(enemyStateManager.getCurrentState() is DeathState) {
                return;
            }
             if(enemyStateManager.getDirection()==1) {
                attackOffset.x=+Math.Abs(attackOffset.x);
            } 
            else {
                attackOffset.x=-Math.Abs(attackOffset.x);
            }
            Transform currentTransform = enemyStateManager.getTransform();
            Vector2 attackPosition = new Vector2(currentTransform.position.x+attackOffset.x, currentTransform.position.y+attackOffset.y);
            Collider2D[] col = Physics2D.OverlapCircleAll(attackPosition,attackRange,layer);
            
            if(col.Length==0) {
                
                enemyStateManager.ChangeState(new ChaseState(enemyStateManager));
                
            }
        }

        public void StartAttack() {
           
        }
        public void TakeDamage() {
            if(enemyStateManager.gameObject.TryGetComponent<HealthController>(out var enemyHealthController)){
                
            }
        }
        public void TeleportToPlayer() {
            Transform playerTransform = enemyStateManager.getPlayerTransform();
            Transform currentTransform = enemyStateManager.getTransform();
            Vector3 newPosition;
            if(currentTransform.position.x>playerTransform.position.x) {
                newPosition = playerTransform.position+new Vector3(teleportOffSet,0,0);
            } 
            else {
                newPosition = playerTransform.position-new Vector3(teleportOffSet,0,0);
            }
            enemyStateManager.Teleport(newPosition);

        }
        public void EndTeleport() {
            enemyStateManager.ChangeState(new ChaseState(enemyStateManager));
        }
        public void OnDrawGizmos() {
            Transform currentTransform = enemyStateManager.getTransform();
            Vector2 attackPosition = new Vector2(currentTransform.position.x+attackOffset.x, currentTransform.position.y+attackOffset.y);
            Gizmos.DrawWireSphere(attackPosition,attackRange);
        }
        public void playAttackSound() {

            AudioManager.instance.PlayClipAt(clipIndex[0]);
        } 
        public void playDeathSound() {
            AudioManager.instance.PlayClipAt(clipIndex[1]);
        } 
        public void playCastSound() {
            AudioManager.instance.PlayClipAt(clipIndex[2]);
        }


        
         
    }
}
