using UnityEngine;

namespace Game
{
    public class LevelManager : MonoBehaviour
    {
        public void Awake() {
            int currentLevelEasy = PlayerPrefs.GetInt("level-easy",-1);
            int currentLevelHard = PlayerPrefs.GetInt("level-hard",-1);
            currentLevelEasy= currentLevelEasy==-1?1:currentLevelEasy;
            currentLevelHard =currentLevelHard==1?2:currentLevelHard;
            PlayerPrefs.SetInt("level-easy",currentLevelEasy);
            PlayerPrefs.SetInt("level-hard", currentLevelHard);
            PlayerPrefs.Save();
        }
        public static int GetCurrentLevel() {
            int difficulty =PlayerPrefs.GetInt("Difficulty",-1);
            string lvSelect = difficulty==0?"level-easy":"level-hard";
            return PlayerPrefs.GetInt(lvSelect,-1);
        } 
        public static int GetCurrentDifficulty() {
            return PlayerPrefs.GetInt("Difficulty",-1);
        }
    }
}
