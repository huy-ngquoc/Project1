using UnityEngine;

namespace Game
{
    public class Red_Hood_Shooting_Area : MonoBehaviour
    {
        [SerializeField] RedHoodScript redHoodScript;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        } 
        private void OnTriggerEnter2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {
                
                redHoodScript.TriggerShooting();
            }
        } 
        private void OnTriggerExit2D(Collider2D col) {
            if(col.gameObject.tag=="Player") {
                
                redHoodScript.ContinueMovingAniaton();
            }
        }
    }
}
