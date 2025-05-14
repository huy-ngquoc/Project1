using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
namespace Game
{
    public class MySceneManager : MonoBehaviour
    {
       public void PressPlayButton() {
          AudioManager.instance.PlayPressButtonSound();
          SceneManager.LoadScene(2);
       }
       public void SetEasy() {
            AudioManager.instance.PlayPressButtonSound();
            PlayerPrefs.SetInt("Difficulty",0); //0:easy
            SceneManager.LoadScene(3);
       }
       public void SetHard() {
            AudioManager.instance.PlayPressButtonSound();
            PlayerPrefs.SetInt("Difficulty",1) ;//1:hard
            SceneManager.LoadScene(3);

       }
       public void BackToHome() {
            AudioManager.instance.PlayPressButtonSound();
            SceneManager.LoadScene(0);
       }
       public void BackToDifficulty() {
            AudioManager.instance.PlayPressButtonSound();
            SceneManager.LoadScene(2);
       } 
       public void SelectLevel1() {
          Debug.Log("Load level1");
          SceneManager.LoadScene(4);
       }
       public void SelectLevel2() {

       } 
       public void SelectLevel3() {

       } 
       public void SelectLevel4() {

       }

    }
}
