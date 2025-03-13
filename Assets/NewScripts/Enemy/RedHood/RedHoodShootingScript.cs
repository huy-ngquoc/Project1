using UnityEngine;

namespace Game
{
    public class RedHoodShootingScript : MonoBehaviour
    {
        [SerializeField] RedHood redHood;
        protected  void OnTriggerEnter2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {
                redHood.ChangeState(new ShootingState(redHood)); 
                Invoke("SpawnArrow",0.5f);
            }
        } 
    public virtual void SpawnArrow(){
        GameObject arrow = redHood.GetArrow();
        Vector3 arrowRotation=new Vector3(0,180-this.redHood.GetDirection(),0);
        Vector3 arrowPosition = this.redHood.GetTransform().position+new Vector3(0,-1,0);
        Instantiate(arrow, arrowPosition, Quaternion.Euler(arrowRotation));
    }
    }
   
}
