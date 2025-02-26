using UnityEngine;
using System;
namespace Game
{
    public class SlimeAttackAreaScript : MonoBehaviour
    {
        [SerializeField] private SlimeScript slimeScript;
        private bool isSetAttackTrigger;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            isSetAttackTrigger=false;
        }

        // Update is called once per frame
        void Update()
        {
        
        } 
        
        private void OnTriggerEnter2D(Collider2D col) { 
            if(slimeScript==null||slimeScript.getHealth()<=0) {
                return;
            }
            if(col.gameObject.tag=="Player") {
                slimeScript.setIsMoving(false);
                slimeScript.getAnimator().SetTrigger("Attack");
                if(isSetAttackTrigger==false) {
                    InvokeRepeating("HandleHitPlayer",0.2f,0.5f);
                    isSetAttackTrigger=true;
                }
            }
        }  
        private void OnTriggerExit2D(Collider2D col) {
            if(slimeScript==null) {
                return;
            } 
            if(col.gameObject.tag=="Player") {
                slimeScript.setIsMoving(true); 
                slimeScript.getAnimator().SetTrigger("StopAttack"); 
                CancelInvoke("HandleHitPlayer");
                isSetAttackTrigger=false;
            }
        } 
        private void HandleHitPlayer() {  
            if(slimeScript==null) {
                return;
            }
            Transform slimeTransform = slimeScript.getTransform(); 
            Transform playerTransform = slimeScript.getPlayerTransform();
            Vector3 attackPosition = slimeTransform.position+new Vector3(-0.3f,0,0);
            float distanceX = attackPosition.x-playerTransform.position.x; 
            float distanceY= attackPosition.y-playerTransform.position.y;
            if(Math.Abs(distanceX)<=1.0f&&Math.Abs(distanceY)<=1.0f) { 
                HitPlayer();

            }
        } 
        private void HitPlayer() {
            Debug.Log("Hit Player");
        }

    }
}
