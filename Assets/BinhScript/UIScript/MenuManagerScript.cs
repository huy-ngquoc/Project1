using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
namespace Game
{
    public class MenuManagerScript : MonoBehaviour
    {
        [SerializeField] Transform pauseMenu;
        [SerializeField] int currentLevel;
        [SerializeField] Transform loseMenu;
        [SerializeField] Transform winMenu;
        [SerializeField] protected int numberOfMonster;
        [SerializeField] protected int destroyedMonster;
        private static MenuManagerScript instance;
        public static MenuManagerScript GetInstance() {
            return instance;
        }
        private void Awake() {
            if(instance==null) {
                instance=this;
            }
            Time.timeScale=1;
        }
        private void Start() {
            Time.timeScale=1;
        }
        public void OnPause() {
            Time.timeScale=0;
            pauseMenu.gameObject.SetActive(true);
        }
        public void OnContinue() {
            Time.timeScale=1;
            pauseMenu.gameObject.SetActive(false);
        }
        public void OnGoBackHome() {
            Time.timeScale=1;
            SceneManager.LoadScene(0);
        }
        public void OnPlayAgain() {
            Time.timeScale=1;
            SceneManager.LoadScene(currentLevel+3);
        }
        public void OnLose() {
            Time.timeScale=0;
            loseMenu.gameObject.SetActive(true);
        }
        public void DelayLose() {
            Invoke("OnLose",2.0f);
        }
        public void OnWin() {
            Time.timeScale=0;
            winMenu.gameObject.SetActive(true);
            if(winMenu.gameObject.TryGetComponent<WinMenuScript>(out var winMenuScript)) {
                Debug.Log("Update current progress");
                winMenuScript.UpdateCurrentProgress();
                winMenuScript.UpdatePlayerScore();
            }
        } 
        public void IncreaseDestroyedMonster() {
            this.destroyedMonster++;
            if(this.destroyedMonster>=numberOfMonster) {
                Invoke("OnWin",2.0f);
            }
        }
        public void OnNextLevel() {
            Time.timeScale=1;
            int difficulty =PlayerPrefs.GetInt("Difficulty",-1);
            string lvSelect = difficulty==0?"level-easy":"level-hard";
            int currentPassLevel= PlayerPrefs.GetInt(lvSelect,-1);
            if(currentLevel>currentPassLevel) {
                currentPassLevel=currentLevel;
            } 
            PlayerPrefs.SetInt(lvSelect,currentPassLevel);
            PlayerPrefs.SetInt("Select_Level",currentLevel+1);
            SceneManager.LoadScene(8);
        } 
        

    }
}
