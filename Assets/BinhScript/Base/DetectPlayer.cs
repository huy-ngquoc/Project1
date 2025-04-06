using UnityEngine;

namespace Game
{
    public class DetectPlayer : MonoBehaviour
    {
        [SerializeField] protected EnemyStateManager enemyStateManager;
        [SerializeField] protected float detectRange;
        [SerializeField] protected LayerMask layer;
        [SerializeField] protected bool isCallChase;
        private void Awake() {
            this.enemyStateManager=GetComponent<EnemyStateManager>();
            this.isCallChase=false;
        }
        // Update is called once per frame
        void Update()
        {
            Vector2 rayCastDir = new Vector2(1,0);
            if(enemyStateManager.getDirection()==0) 
            {
                rayCastDir= new Vector2(-1,0);
            }
            RaycastHit2D hit = Physics2D.Raycast(transform.position,rayCastDir,detectRange,layer); 
            if(hit.collider) {
                if(hit.point.x<=enemyStateManager.getBorederRight()&&hit.point.x>=enemyStateManager.getBorderLeft()) {
                    if(!isCallChase) {
                        enemyStateManager.setPlayerTransform(hit.collider.gameObject.transform);
                        enemyStateManager.ChangeState(new ChaseState(enemyStateManager));
                        isCallChase=true;
                    }
                }

            }
            else {
                isCallChase=false;
            }
           
        }
        /*void OnDrawGizmos() {
             Gizmos.DrawLine(transform.position, transform.position+Vector3.left*detectRange);
        }*/
    }
}
