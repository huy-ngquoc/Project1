using UnityEngine;
using System;
namespace Game
{
    public class RedHoodShootingZone : MonoBehaviour
    {
        [SerializeField] protected MonsterScript monsterScript;
        [SerializeField] protected GameObject arrow;  
        [SerializeField] protected Transform redHoodTransform; 
        protected virtual void Start() {
            
        }
        protected virtual void OnTriggerEnter2D(Collider2D col) {
            if(col.gameObject.tag=="Player") { 
                if(HandleShoot()) {
                    monsterScript.SetState(State.attack2); 
                    monsterScript.AnimationControl();   
                    Invoke("Shoot",0.5f);
                    
                    

                }
                

                
            }
        }   
        protected virtual void Shoot() {
            SpawnArrow();
            StopShoot();
        } 
        protected virtual void StopShoot() {
            monsterScript.SetState(State.move);
            monsterScript.AnimationControl(); 
            
        }
        protected virtual bool HandleShoot() { 
            System.Random rand = new System.Random();
                int randomNumber=rand.Next(1,11);
                if(randomNumber<=7) {
                    return true;
                } 
                return false;

        }
        protected virtual void SpawnArrow() { 
            Vector3 arrowRotation=new Vector3(0,180-monsterScript.GetDirection(),0);
            Instantiate(arrow, redHoodTransform.position, Quaternion.Euler(arrowRotation));
        }
    }
}
