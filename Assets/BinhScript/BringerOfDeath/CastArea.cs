using UnityEngine;
using System;
namespace Game
{
    public class CastArea : MonoBehaviour
    {
        [SerializeField] protected EnemyStateManager enemyStateManager;
        [SerializeField] protected LayerMask layer;
        [SerializeField] protected float maxCastRange;
        [SerializeField] protected float minCastRange;
        protected void Awake() {
            this.enemyStateManager=GetComponent<EnemyStateManager>();
        }
        protected void Update() {
            Vector2 rayCastDir = new Vector2(1,0);
            if(enemyStateManager.getDirection()==0) {
                rayCastDir=new Vector2(-1,0);
            } 
            RaycastHit2D hit = Physics2D.Raycast(transform.position,rayCastDir,maxCastRange,layer);
            if(hit) {
                float distance = Math.Abs(hit.collider.gameObject.transform.position.x-transform.position.x);
                if(distance<minCastRange) {
                    return;
                } 
                if(!(enemyStateManager.getCurrentState() is CastState)) {
                    enemyStateManager.ChangeState(new CastState(this.enemyStateManager));
                }
            }
        }
    }
}
