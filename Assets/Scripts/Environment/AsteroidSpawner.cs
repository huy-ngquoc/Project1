using UnityEngine;

namespace Game
{
    public class AsteroidSpawner : MonoBehaviour
    {
        [SerializeField] protected float spawnTime;
        [SerializeField] protected Transform transform;
        [SerializeField] protected GameObject asteroid;
        
        protected void Awake() {
            spawnTime=10;
            transform=GetComponent<Transform>(); 
            InvokeRepeating("SpawnAsteroid",0,spawnTime);
        } 
        protected void SpawnAsteroid() {
            Vector3 spawnPoition= new Vector3(transform.position.x, transform.position.y+10,0); 
            GameObject asObject=Instantiate(asteroid,spawnPoition,transform.rotation); 
            AsteroidScript asScript ;
            asObject.TryGetComponent<AsteroidScript>(out asScript);
            
            asScript.SetIsCollide(false); 
            asScript.SetSpeed(0.1f);
        }
    }
}
