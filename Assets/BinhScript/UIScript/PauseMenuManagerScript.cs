using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
namespace Game
{
    public class PauseMenuManagerScript : MonoBehaviour
    {
        [SerializeField] Transform pauseMenu;
        [SerializeField] int currentLevel;
        private void Awake() {
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
    }
}
