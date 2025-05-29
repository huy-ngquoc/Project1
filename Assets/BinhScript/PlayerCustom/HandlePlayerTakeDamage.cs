using UnityEngine;

namespace Game
{
    public class HandlePlayerTakeDamage : MonoBehaviour
    {
        [SerializeField] protected Rigidbody2D rigidBody;
        protected void Awake() {
            this.rigidBody = GetComponent<Rigidbody2D>();
        }
        public void TakeDamage(Vector2 forceDirection, Transform attacker) {
            
            if(attacker.position.x>transform.position.x) {
                forceDirection.x=-forceDirection.x;
            }
            this.rigidBody.AddForce(forceDirection,ForceMode2D.Impulse); 
            if(this.gameObject.TryGetComponent<EntityController>(out var entityController)) {
                entityController.DoTakeDamageEffect();
            }
            Debug.Log("Player get hit by Binh's enemies");
        }
    }
}
