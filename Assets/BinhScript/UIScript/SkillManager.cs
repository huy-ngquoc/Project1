using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
namespace Game
{
    public class SkillManager : MonoBehaviour
    {
        private static SkillManager instance;
        public static SkillManager getInstance() {
            return instance;
        } 
        protected void Awake() {
            if(instance==null) {
                instance=this;
            } 
            PlayerPrefs.SetInt("Player_Score",200);
            LoadScoreText();

        }
        [SerializeField] private SkillNode currentSkill;
        [SerializeField] private SkillInfo skillInfo;
        [SerializeField] private Transform backGroundTransform;
        [SerializeField] private TextMeshProUGUI scoreText;
        public void setCurrentSkill(SkillNode currentSkill) {
            this.currentSkill = currentSkill;
            Debug.Log("Select Skill"+currentSkill.getSkillName());
            SkillInfo newSkillInfo =Instantiate(skillInfo, backGroundTransform,false);
            newSkillInfo.setCurrentSelectedSkill(this.currentSkill);
        } 
        
        public Transform getBackGroundTransform() {
            return this.backGroundTransform;
        }
        public void LoadScoreText() {
            scoreText.text = ""+PlayerPrefs.GetInt("Player_Score",0);
        }

    }
}
