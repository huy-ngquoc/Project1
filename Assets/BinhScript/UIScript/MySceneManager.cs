using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
namespace Game
{
    public class MySceneManager : MonoBehaviour
    {
       public void PressPlayButton() {
        SceneManager.LoadScene(2);
       }
       public void SetEasy() {
            PlayerPrefs.SetInt("Difficulty",0); //0:easy
            SceneManager.LoadScene(3);
       }
       public void SetHard() {
            PlayerPrefs.SetInt("Difficulty",1) ;//1:hard
            SceneManager.LoadScene(3);

       }
       public void BackToHome() {
            SceneManager.LoadScene(0);
       }
       public void BackToDifficulty() {
            SceneManager.LoadScene(2);
       } 

    }
}
