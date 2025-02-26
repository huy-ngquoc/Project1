using UnityEngine;

namespace Game
{
    public class MonsterScript:MonoBehaviour
    {
        [SerializeField] protected float speed;
        protected int direction;
        protected Transform transform;  
        protected Animator animator;
        [SerializeField] protected Transform playerTransform;
        protected  void ChangeDirection() { 
            Vector3 newDirection = new Vector3(transform.position.x,direction, transform.rotation.z);
            transform.rotation=Quaternion.Euler(newDirection);

        }
        public  void MonsterMove() 
        {
            if(transform==null) {
                return;
            }
            if(direction==0) {
                transform.position+=new Vector3(-speed*Time.deltaTime,0,0);

            }
            else {
                if(direction==180) {
                    transform.position+=new Vector3(speed*Time.deltaTime,0,0);
                }
            }
        } 
         protected void OnCollisionEnter2D(Collision2D col) { 
            if(transform==null) {
                return;
            }
            if(col.gameObject.tag=="Border") {
                if(direction==0) {
                    direction=180;
                } 
                else {
                    direction=0;
                } 
                ChangeDirection();
                

            }
        }
    }
}
