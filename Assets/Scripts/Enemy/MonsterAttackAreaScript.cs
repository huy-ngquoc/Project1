using UnityEngine;

namespace Game
{
    public class MonsterAttackAreaScript : MonoBehaviour
    { 
        [SerializeField] protected MonsterScript monsterScript; 
        [SerializeField] protected bool isCallInvoke;
        [SerializeField] protected float attackSpeed;
        [SerializeField] protected Vector3 position;
        protected virtual void Start() {
            isCallInvoke=false;
        } 
        protected virtual void Update() {
            ResetPosition();
        }
        protected virtual void OnTriggerEnter2D(Collider2D col) {
            if(col.gameObject.tag=="Player") { 
                monsterScript.SetState(State.attack1);
                monsterScript.AnimationControl(); 
                
            }
        }
        protected virtual void OnTriggerExit2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {
                monsterScript.SetState(State.chase);
                monsterScript.AnimationControl();
                isCallInvoke=false; 
                CancelInvoke("HitPlayer");
            }
        } 
        protected virtual void OnTriggerStay2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {  
                if(isCallInvoke) {
                    return;
                }
                InvokeRepeating("HitPlayer",0.5f,attackSpeed); 
                isCallInvoke=true;

            }
        }
        protected virtual void HitPlayer() { 
            if(monsterScript.GetState()!=State.attack1) {
                return;
            }
            Debug.Log("Hit Player");

        } 
        protected virtual void ResetPosition() {
            Transform transform = GetComponent<Transform>();
            transform.localPosition= position; 
            transform.localRotation =  Quaternion.Euler(0,0,0);
        }
    }
}
