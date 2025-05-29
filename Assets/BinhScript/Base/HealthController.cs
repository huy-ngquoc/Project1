using UnityEngine;
using UnityEngine.UI;
namespace Game
{
    public class HealthController : MonoBehaviour
    {
        [SerializeField] protected Image foreGround;
        [SerializeField] protected float maxHealth;
        [SerializeField] protected float currentHealth;
        [SerializeField] protected EnemyStateManager enemyStateManager;
        [SerializeField] protected float[] attackDamage;
        [SerializeField] protected Canvas canvas;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        
        public void Awake() {
            this.enemyStateManager=GetComponent<EnemyStateManager>();
            this.currentHealth=this.maxHealth;
        }
        public void UpdateHealthBar() {
            
            foreGround.fillAmount = currentHealth/maxHealth;
        }
        public float GetCurrentHealth() {
            return this.currentHealth;
        }
        public float TakeDamageAt(int index){
            if(index>=attackDamage.Length) {
                return 0;
            } 
            return attackDamage[index];
        }
        public void TakeDamage(float damage) {
            this.currentHealth-=damage;
            if(this.currentHealth<=0) { 
                currentHealth=0;
                enemyStateManager.ChangeState(new DeathState(enemyStateManager));
            } 
            
            UpdateHealthBar();
            enemyStateManager.TakeDamage();
        }
        public Canvas GetCanvas() {
            return this.canvas;
        }
        public void SetMaxHealth(float maxHealth) {
            this.maxHealth=maxHealth;
        }
        public float GetMaxHealth() {
            return this.maxHealth;
        }
    }
}
