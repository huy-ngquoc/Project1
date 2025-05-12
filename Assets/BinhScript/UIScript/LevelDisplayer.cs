using UnityEngine;

namespace Game
{
    public class LevelDisplayer : MonoBehaviour
    {
        [SerializeField] protected GameObject lockIcon;
        public void Awake() {
            int indexInParent = this.transform.GetSiblingIndex();
            Debug.Log(indexInParent);
            int currentLevel = LevelManager.GetCurrentLevel();
            if(indexInParent+1>currentLevel) {
                Instantiate(lockIcon,transform.GetChild(0),false);
            }
        }
    }
}
