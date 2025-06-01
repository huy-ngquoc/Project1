using UnityEngine;

namespace Game
{
    public class PlayerSkillLoader : MonoBehaviour
    {
        
        public void Awake() {
            int currentSkill = PlayerPrefs.GetInt("Chosen_Skill",-1);
            

        }
    }
}
