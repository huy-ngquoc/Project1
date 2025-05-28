using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace Game
{
    public class CurrentSkillImage : MonoBehaviour
    {
        [SerializeField] Image image;
        private static CurrentSkillImage instance;
        public static CurrentSkillImage getInstance() {
            return instance;
        } 
        private void Start() {
            if(instance==null) {
                instance=this;
            } 
            image=GetComponent<Image>();
            LoadImage();
        }
        public void LoadImage() {
            int currentChoosenSkill = PlayerPrefs.GetInt("Chosen_Skill",-1);
            if(currentChoosenSkill==-1) {
                return;
            } 
            SkillNode  skill = SkillManager.getInstance().getSkillAt(currentChoosenSkill-1);
            image.sprite = skill.getSkillImage();
        }
    }
}
