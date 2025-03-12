using UnityEngine;

namespace Game
{
    public class ElevatorScript : MonoBehaviour
    {
        [SerializeField] protected Transform transform;
        [SerializeField] protected float speed;
        [SerializeField] protected int direction; 
        [SerializeField] protected float borderLeft;
        [SerializeField] protected float borderRight;
        protected void Awake() {
            this.transform=GetComponent<Transform>();
            this.speed=1;
            this.direction=1;
        } 
        protected void Update() {
            if(transform.position.x<=borderLeft) {
                this.direction=1;
            } 
            if(transform.position.x>=borderRight) {
                this.direction=-1;
            } 
            this.transform.position+=new Vector3(speed*Time.deltaTime*direction,0,0);
        }
    }
}
