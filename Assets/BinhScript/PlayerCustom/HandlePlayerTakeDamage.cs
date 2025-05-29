using UnityEngine;

namespace Game
{
    public class HandlePlayerTakeDamage : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rigidBody;
        [SerializeField] protected EntityStats entityStats;
        protected void Awake() {
            this.rigidBody = GetComponent<Rigidbody2D>();
            this.entityStats= GetComponent<EntityStats>();
        }
        public void TakeDamage(Vector2 forceDirection, Transform attacker) {
           
            if(attacker.position.x>transform.position.x) {
                forceDirection.x=-forceDirection.x;
            }
            this.rigidBody.AddForce(forceDirection,ForceMode2D.Impulse);  
            if(attacker.gameObject.TryGetComponent<EnemyStateManager>(out var enemyStateManager)) {
                this.entityStats.DecreaseHealthBy(enemyStateManager.GetAttackDamage());
                Debug.Log("Slime Attack");
                if(this.entityStats.GetCurrentHealth()<=0) {
                    this.entityStats.Die();
                }
            }
            if(this.gameObject.TryGetComponent<EntityController>(out var entityController)) {
                entityController.DoTakeDamageEffect();
                
            }
            
            
        }
    }
}
