using UnityEngine;

namespace Game
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] protected EnemyStateManager stateManager;  
        [SerializeField] protected Transform playerTransform;
        [SerializeField] protected float detectRange;
        protected void Awake() {
            this.stateManager= this.GetComponent<EnemyStateManager>();
        } 
        public void DetectPlayer() {

        }
    }
}
