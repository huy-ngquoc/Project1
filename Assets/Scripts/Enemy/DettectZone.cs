using UnityEngine;

namespace Game
{
    public class DettectZone : MonoBehaviour
    {
       [SerializeField] protected WolfScript monsterScript; 
       protected virtual void OnTriggerEnter2D(Collider2D col) { 
            if(col.gameObject.tag=="Player") {
                monsterScript.SetState(State.chase); 
            }
       }
       protected virtual void OnTriggerExit2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {
                monsterScript.SetState(State.move);
            }
       }

    }
}
