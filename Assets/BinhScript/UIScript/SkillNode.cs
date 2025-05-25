using UnityEngine;
using UnityEngine.UI;
namespace Game
{ 
    
    public class SkillNode:MonoBehaviour
    {
        [SerializeField] private string skillName;
        [SerializeField] private bool isUnlock;
        [SerializeField] private string description;
        [SerializeField] private int scoreRequire;
        [SerializeField] private Sprite skillImage;
        [SerializeField] private SkillNode parent;
        [SerializeField] private Sprite lockImage;
        [SerializeField] private int skillId;
        private void Awake() {
            LoadImage();
        }
        public void LoadImage() {
            Image image = GetComponent<Image>(); 
            int chosenSkillId = PlayerPrefs.GetInt("Chosen_Skill",-1);

            if(this.isUnlock||chosenSkillId == this.skillId) {
                image.sprite = skillImage; 
            } 
            else {
                image.sprite = lockImage;
            }
        }
        public void SelectCurrentSkill() {
            SkillManager.getInstance().setCurrentSkill(this);
        }
        public string getSkillName() {
            return this.skillName;
        }
        public bool getUnlock() {
            return this.isUnlock;
        } 
        public string getDescription() {
            return this.description;
        } 
        public int getScoreRequire() {
            return this.scoreRequire;
        } 
        public Sprite getSkillImage() {
            return this.skillImage;
        } 
        public SkillNode getParent() {
            return this.parent;
        } 
        public int getSkillId() {
            return this.skillId;
        }
        public void SetUnlock(bool unlockState) {
            this.isUnlock = unlockState;
        }
        
        
    }
}
