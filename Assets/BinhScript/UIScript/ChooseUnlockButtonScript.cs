using UnityEngine;
using TMPro;
using UnityEngine.UI; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
namespace Game
{
    public class ChooseUnlockButtonScript : MonoBehaviour
    {
        [SerializeField] private SkillNode currentSkill;
        [SerializeField] private Text buttonText;
        [SerializeField] private Alert alert;
        [SerializeField] private bool isChoose;
        [SerializeField] private SkillInfo skillInfo;
        public void setCurrentSkill(SkillNode currentSkill) {
            this.currentSkill = currentSkill;
        } 
        public void LoadButtonText() {
            if(currentSkill.getUnlock()==true&&currentSkill.getSkillId()!=1) {
                buttonText.text="Choose";
                isChoose =true;
            } 
            else {
                buttonText.text ="Unlock"; 
                isChoose = false;
            }  
        } 
        public void OnPress() {
            if(isChoose) {
                PlayerPrefs.SetInt("Chosen_Skill",currentSkill.getSkillId());
                PlayerPrefs.Save();
                CurrentSkillImage.getInstance().LoadImage();
                Destroy(this.gameObject);
            } 
            else {
                Debug.Log("Unlock");
                Alert newAlert = Instantiate(alert,SkillManager.getInstance().getBackGroundTransform(),false); 
                newAlert.FakeContructor(this.currentSkill, skillInfo);
            }
        }

    }
}
