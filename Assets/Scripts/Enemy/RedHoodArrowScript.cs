using UnityEngine;

namespace Game
{
    public class RedHoodArrowScript : MonoBehaviour
    { 
        private Transform transform;
        [SerializeField] private float moveSpeed;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            transform = GetComponent<Transform>();
        }

        // Update is called once per frame
        void Update()
        {
        } 
        private void FixedUpdate() {
            MoveForward();
        }
        private void MoveForward() 
        {
            if(transform==null) {
                return;
            } 
            transform.Translate(Vector3.right*moveSpeed*Time.deltaTime);

            if(transform.position.x>=100||transform.position.x<=-100) {
                Destroy(gameObject);
            }
        }
        private void OnTriggerEnter2D(Collider2D col) { 
            if(col.gameObject.tag=="Player") {
                Debug.Log("Hit player");
                Destroy(gameObject);
            }

        }
    }  
}
