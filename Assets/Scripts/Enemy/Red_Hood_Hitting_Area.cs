using UnityEngine;

namespace Game
{
    public class Red_Hood_Hitting_Area : MonoBehaviour
    { 
        [SerializeField] private RedHoodScript redHoodScript;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        } 
        private void OnTriggerEnter2D(Collider2D col) {
            if(col.gameObject.tag=="Player") { 
                redHoodScript.StopMoving();
                redHoodScript.ShootToHitAnimation();
            }
        }
        private void OnTriggerExit2D(Collider2D col) {
            if(col.gameObject.tag=="Player") { 
                redHoodScript.ContinueMoving();
                redHoodScript.StopAttackAnimation();
            }
        }
    }
}
