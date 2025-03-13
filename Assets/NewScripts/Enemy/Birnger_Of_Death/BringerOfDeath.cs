using UnityEngine;

namespace Game
{
    public class BringerOfDeath : EnemyStateManager
    {
        
        public void Teleport() {  
            float distance = this.transform.position.x-playerTransform.position.x;
            Vector3 offsetVector;
            if(distance<0) 
            {
                offsetVector=new Vector3(-4,0,0);
            } 
            else {
                offsetVector= new Vector3(4,0,0);
            }
            this.SetPosition(this.GetPlayerTransform().position+offsetVector);
            this.ChangeState(new ChaseState(this));
        }  
        public void BackToChaseState() {
            
        }

        
        
    }
}
