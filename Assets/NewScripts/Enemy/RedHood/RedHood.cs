using UnityEngine;

namespace Game
{
    public class RedHood : EnemyStateManager
    {
        [SerializeField] protected GameObject arrow;
        public GameObject GetArrow() {
            return this.arrow;
        }
    }
}
