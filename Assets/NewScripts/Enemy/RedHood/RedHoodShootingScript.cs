using UnityEngine;

namespace Game
{
    public class RedHoodShootingScript : MonoBehaviour
    {
        [SerializeField] RedHood redHood;
        protected  void OnTriggerEnter2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {
                redHood.ChangeState(new ShootingState(redHood));
            }
        }
    }
}
