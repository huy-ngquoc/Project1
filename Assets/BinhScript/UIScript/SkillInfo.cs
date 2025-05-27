using UnityEngine;
using TMPro;
using UnityEngine.UI; 

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
namespace Game
{
    public class SkillInfo : MonoBehaviour
    {
        [SerializeField] protected SkillNode currentSelectedSkill;
        [SerializeField] protected TextMeshProUGUI skillName;
        [SerializeField] protected TextMeshProUGUI skillDescription;
        [SerializeField] protected Image skillImage;
        [SerializeField] protected ChooseUnlockButtonScript unlockButton;
        [SerializeField] protected Button closeButton;
        [SerializeField] protected Alert alert;
        
        public void setCurrentSelectedSkill(SkillNode currentSelectedSkill) { 
            this.currentSelectedSkill = currentSelectedSkill; 
            Debug.Log(this.currentSelectedSkill);
            skillName.text = this.currentSelectedSkill.getSkillName();
            skillDescription.text = this.currentSelectedSkill.getDescription();
            skillImage.sprite = this.currentSelectedSkill.getSkillImage();
            DisplayUnlockButton();

        }
        private void DisplayUnlockButton() {
            int chosenSkillId = PlayerPrefs.GetInt("Chosen_Skill",-1);
            if(chosenSkillId==this.currentSelectedSkill.getSkillId()) {
                Debug.Log(this.currentSelectedSkill.getSkillId());
                unlockButton.gameObject.SetActive(false);
            }
            if(this.currentSelectedSkill.getUnlock()) {
                unlockButton.setCurrentSkill(this.currentSelectedSkill);
                unlockButton.LoadButtonText();
                return;
            }
            int playerCurrentScore = PlayerPrefs.GetInt("Player_Score",0);
            
            if(this.currentSelectedSkill.getScoreRequire()>playerCurrentScore) {
                unlockButton.gameObject.SetActive(false);
            }
            if(this.currentSelectedSkill.getParent()?.getUnlock()==false) {
                unlockButton.gameObject.SetActive(false);
            }
            unlockButton.setCurrentSkill(this.currentSelectedSkill);
            unlockButton.LoadButtonText();
        }
        public void OnClose() {
            Destroy(this.gameObject);
        }
        public void OnUnlock() {
            Alert newAlert =Instantiate(alert,SkillManager.getInstance().getBackGroundTransform(),false); 
            newAlert.FakeContructor(this.currentSelectedSkill, this);

        }
        private void Awake() {
            //Fake Score 
        }
    }
}
