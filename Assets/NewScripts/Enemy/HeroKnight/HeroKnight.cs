using UnityEngine;

namespace Game
{
    public class HeroKnight : EnemyStateManager
    {
        [SerializeField] protected float attack2Time;
        [SerializeField] protected float hitPlayerTime;
        public float GetAttack2Time() {
            return this.attack2Time;
        } 
        public float GetHitPlayerTime() {
            return this.hitPlayerTime;
        } 
        public void Attack2Player() {
            AttackPlayer(); 
            Invoke("BackToPreviousState",0.15f);
        }
        
    }
}
