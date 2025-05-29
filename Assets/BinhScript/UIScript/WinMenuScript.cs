using UnityEngine;

namespace Game
{
    public class WinMenuScript : MonoBehaviour
    {
        [SerializeField] private int[] levelScores= {100,200,300,400};
        [SerializeField] private int currentLevel;
        [SerializeField] Transform nextLevelButton;
        [SerializeField] Transform homeButton;
        [SerializeField] Transform playAgainButton;
        [SerializeField] Transform winText;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        public void UpdateCurrentProgress() {
            int difficulty =PlayerPrefs.GetInt("Difficulty",-1);
            string lvSelect = difficulty==0?"level-easy":"level-hard";
            int currentLevel = PlayerPrefs.GetInt(lvSelect,-1);
            if(currentLevel!=-1) {
                currentLevel++;
            } 
            PlayerPrefs.SetInt(lvSelect,currentLevel);
        }
        public void UpdatePlayerScore() {
            int currentPlayerScore = PlayerPrefs.GetInt("Player_Score");
            currentPlayerScore+=levelScores[currentLevel];
            PlayerPrefs.SetInt("Player_Score",currentPlayerScore);
        }
        public void OnContinue() {
            int difficulty =PlayerPrefs.GetInt("Difficulty",-1);
            string lvSelect = difficulty==0?"level-easy":"level-hard";
            int currentLevelSelect= PlayerPrefs.GetInt(lvSelect,-1);
            currentLevelSelect++;
            PlayerPrefs.SetInt("Select_Level",currentLevel);
        }
        public void LoadNextLevelButton() {
            int difficulty =PlayerPrefs.GetInt("Difficulty",-1);
            string lvSelect = difficulty==0?"level-easy":"level-hard";
            int currentLevelSelect= PlayerPrefs.GetInt(lvSelect,-1);
            if(currentLevelSelect==4) {
                nextLevelButton.gameObject.SetActive(false);
                winText.localPosition = new Vector3(0,75,0);
                homeButton.localPosition= new Vector3(0,0,0);
                playAgainButton.localPosition= new Vector3(0,-75,0);
            }
        }
    }
}
