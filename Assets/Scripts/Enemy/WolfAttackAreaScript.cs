using UnityEngine;

namespace Game
{
    public class WolfAttackAreaScript : MonoBehaviour
    { 
        [SerializeField] protected WolfScript wolfScript; 
        [SerializeField] protected bool isCallInvoke;
        protected virtual void Start() {
            isCallInvoke=false;
        }
        protected virtual void OnTriggerEnter2D(Collider2D col) {
            if(col.gameObject.tag=="Player") { 
                wolfScript.SetState(State.attack1);
                wolfScript.AnimationControl(); 
                
            }
        }
        protected virtual void OnTriggerExit2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {
                wolfScript.SetState(State.chase);
                wolfScript.AnimationControl();
                isCallInvoke=false; 
                CancelInvoke("HitPlayer");
            }
        } 
        protected virtual void OnTriggerStay2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {  
                if(isCallInvoke) {
                    return;
                }
                InvokeRepeating("HitPlayer",0.5f,0.883f); 
                isCallInvoke=true;

            }
        }
        protected virtual void HitPlayer() { 
            Debug.Log("Hit Player");

        }
    }
}
