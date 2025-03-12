using UnityEngine;
using System;
namespace Game
{
    public class AsteroidScript : MonoBehaviour
    {
        [SerializeField] protected Vector3 targetTransform;
        [SerializeField] protected Transform transform;
        [SerializeField] protected float speed; 
        [SerializeField] protected Vector3 directionVector;
        [SerializeField] protected GameObject asteroid;
        [SerializeField] protected GameObject fireBomb;
        [SerializeField] bool isCollide; 
        
        protected void Start() {
            this.transform=GetComponent<Transform>();
            speed=0.1f;
            System.Random rand = new System.Random();
            int targetX= rand.Next(-27,33);
            targetTransform = new Vector3(targetX,-4,0);
            Transform asteroidTransform= transform.GetChild(0);
            asteroid=asteroidTransform.gameObject;
            Transform fireBombTransform = transform.GetChild(1);
            fireBomb=fireBombTransform.gameObject;
            float x=transform.position.x-targetTransform.x;
            float y=transform.position.y-targetTransform.y;
            fireBomb.SetActive(false);
            isCollide=false;
           
            directionVector= new Vector3(x*speed*Time.deltaTime,y*speed*Time.deltaTime,0); 
            
        }
        protected void Update() { 
            
        }
        protected void FixedUpdate() {
            if(isCollide) {
                return;
            }
            transform.position-=directionVector;
        }
        protected void OnTriggerEnter2D(Collider2D col) { 
            if(col.gameObject.tag=="Map") {
                asteroid.SetActive(false);
                
                fireBomb.SetActive(true);
                this.GetComponent<Rigidbody2D>().isKinematic=true; 
                isCollide=true;
                Invoke("DestroyAsteroid",1.5f); 
            }
        } 
        protected void DestroyAsteroid() {
            Destroy(this.gameObject);
        } 
        
         
        public void SetIsCollide(bool isCollide) {
            this.isCollide=isCollide;
        }
        public void SetSpeed(float speed) {
            this.speed=speed;
        }
    }
}
