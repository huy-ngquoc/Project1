using UnityEngine;

namespace Game
{
    public class Arrow : MonoBehaviour
    {
        
        [SerializeField] protected Transform transform; 
        [SerializeField] protected float speed;
        protected virtual void Start() {
            transform = GetComponent<Transform>(); 
            speed=5.0f;
            
        }
        protected virtual void Move() {
            if(transform.position.x>=100||transform.position.x<=-100) {
                Destroy(gameObject);
            }
            if(transform.rotation.y==-1) {
                transform.position+= new Vector3(-speed*Time.deltaTime,0,0);
            } 
            else {
                transform.position+=new Vector3(speed*Time.deltaTime,0,0);
            }

        }
        protected virtual void Update() {
            Move();
        }
    }
}
