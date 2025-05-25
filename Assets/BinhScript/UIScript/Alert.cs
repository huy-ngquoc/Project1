using UnityEngine;
using UnityEngine.UI; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
namespace Game
{
    public class Alert : MonoBehaviour
    {
        [SerializeField] protected SkillNode currentSkill;
        [SerializeField] protected SkillInfo skillInfo;
        public void FakeContructor(SkillNode currentSkill, SkillInfo skillInfo) {
            this.currentSkill=currentSkill;
            this.skillInfo = skillInfo;
        }
        public void OnYes() {
            OnUnlock();
            Destroy(skillInfo.gameObject);
            Destroy(this.gameObject);


        } 
        public void OnNo() {
            Destroy(this.gameObject);
        }
        public void OnUnlock() {
            string skillRef ="Skill "+this.currentSkill.getSkillId();
            PlayerPrefs.SetInt(skillRef,1); 
            int currentScore = PlayerPrefs.GetInt("Player_Score",-1);
            currentScore -= this.currentSkill.getScoreRequire();
            PlayerPrefs.SetInt("Player_Score", currentScore);
            this.currentSkill.SetUnlock(true);
            this.currentSkill.LoadImage();
            SkillManager.getInstance().LoadScoreText();
            PlayerPrefs.Save();
        }
    }
}
