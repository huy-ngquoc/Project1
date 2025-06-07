using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
namespace Game
{
    public class MySceneManager : MonoBehaviour
    {
     [SerializeField] protected int playerScore;
       public void PressPlayButton() {
          AudioManager.instance.PlayPressButtonSound();
          SceneManager.LoadScene(2);
       }
       public void BackToLevel() {
          SceneManager.LoadScene(3);
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
          PlayerPrefs.SetInt("Select_Level",1);
          PlayerPrefs.Save();
          SceneManager.LoadScene(8);
       }
       public void SelectLevel2() { 
          PlayerPrefs.SetInt("Select_Level",2);
          PlayerPrefs.Save(); 
          SceneManager.LoadScene(8);

       } 
       public void SelectLevel3() { 
          PlayerPrefs.SetInt("Select_Level",3);
          PlayerPrefs.Save(); 
          SceneManager.LoadScene(8);
       } 
       public void SelectLevel4() { 
          PlayerPrefs.SetInt("Select_Level",4);
          PlayerPrefs.Save(); 
          SceneManager.LoadScene(8);

       }
       public void SetPlayerScore() {
          int currentScore = PlayerPrefs.GetInt("Player_Score",-1);
          playerScore = currentScore==-1?0:currentScore;
       }
       public void OnPlay() {
          int selectLevel = PlayerPrefs.GetInt("Select_Level",1);
          Debug.Log("Play at level" +selectLevel);
          SceneManager.LoadScene(selectLevel+3);
       }

    }
}
