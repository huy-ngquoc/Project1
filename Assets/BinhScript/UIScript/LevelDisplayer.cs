using UnityEngine;

namespace Game
{
    public class LevelDisplayer : MonoBehaviour
    {
        [SerializeField] protected GameObject lockIcon;
        public void Awake() {
            int indexInParent = this.transform.GetSiblingIndex();
            
            int currentLevel = LevelManager.GetCurrentLevel();
            if(indexInParent+1>currentLevel) {
                Debug.Log(currentLevel);
                Instantiate(lockIcon,transform.GetChild(0),false);
            }
        }
    }
}
