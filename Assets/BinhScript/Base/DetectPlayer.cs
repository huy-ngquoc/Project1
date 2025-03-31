using UnityEngine;

namespace Game
{
    public class DetectPlayer : MonoBehaviour
    {
        [SerializeField] protected EnemyStateManager enemyStateManager;
        [SerializeField] protected float detectRange;
        [SerializeField] protected LayerMask layer;
        private void Awake() {
            this.enemyStateManager=GetComponent<EnemyStateManager>();
        }
        // Update is called once per frame
        void Update()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.left,detectRange,layer); 
            if(hit.collider) {
                if(hit.point.x<=enemyStateManager.getBorederRight()&&hit.point.x>=enemyStateManager.getBorderLeft()) {
                    if(!(enemyStateManager.getCurrentState() is ChaseState)) {
                        enemyStateManager.setPlayerTransform(hit.collider.gameObject.transform);
                        enemyStateManager.ChangeState(new ChaseState(enemyStateManager));
                    }
                }
            }
        }
        void OnDrawGizmos() {
            Gizmos.DrawLine(transform.position, transform.position+Vector3.left*detectRange);
        }
    }
}
