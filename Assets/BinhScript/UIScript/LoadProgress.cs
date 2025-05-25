using UnityEngine;

namespace Game
{
    public class LoadProgress : MonoBehaviour
    {
        [SerializeField] protected int currentDifficulty;
        [SerializeField] protected int currentLevel;
        public void Awake() {
            this.currentDifficulty = PlayerPrefs.GetInt("Difficulty",-1);
            if(this.currentDifficulty==0) {
                this.currentLevel = PlayerPrefs.GetInt("level-easy",-1);
            } 
            if(this.currentDifficulty==1) {
                this.currentLevel=PlayerPrefs.GetInt("level-hard",-1);
            }
        }
    }
}
