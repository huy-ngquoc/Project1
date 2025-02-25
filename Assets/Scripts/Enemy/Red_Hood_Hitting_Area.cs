using UnityEngine; 
using System;

namespace Game
{
    public class Red_Hood_Hitting_Area : MonoBehaviour
    { 
        [SerializeField] private RedHoodScript redHoodScript; 
        private bool isCallingHit;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            isCallingHit=false;
        }

        // Update is called once per frame
        void Update() 
        {
        
        } 
        private void OnTriggerEnter2D(Collider2D col) { 
            if(redHoodScript==null) {
                return;
            }
            if(col.gameObject.tag=="Player") { 
                redHoodScript.StopMoving();
                redHoodScript.ShootToHitAnimation();  
                if(isCallingHit==false) {
                    InvokeRepeating("HitPlayer",1.0f,1.0f);  
                    isCallingHit=true;
                }

            }
        }
        private void OnTriggerExit2D(Collider2D col) { 
            if(redHoodScript==null) {
                return;
            }
            if(col.gameObject.tag=="Player") { 
                redHoodScript.ContinueMoving();
                redHoodScript.StopAttackAnimation(); 
                isCallingHit=false; 
                CancelInvoke("HitPlayer");
            }
        }
        private void HitPlayer() { 
            
            
                if(CalculatePlayerPosition(redHoodScript.getPlayerTransform(), redHoodScript.getRedHoodTransform())) {
                    Debug.Log("Hit player"); 
                    
                }


            
        } 
        private bool CalculatePlayerPosition(Transform playerTransform, Transform redHoodTransform) {  
            
            float distanceX= playerTransform.position.x-redHoodTransform.position.x;
            float distanceY= playerTransform.position.y-redHoodTransform.position.y;
            if(Math.Abs(distanceX)<=2.0f&&Math.Abs(distanceY)<=2.0f) { 
                return true;
                
            } 
            return false;

        }
    }
}
