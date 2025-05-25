using UnityEngine;

namespace Game
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] protected AudioSource audioSource;
        [SerializeField] protected AudioClip buttonPressClip;
        public static AudioManager instance;
        private void Awake() {
            this.audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            if(AudioManager.instance==null) {
                AudioManager.instance=this;
            }
            DontDestroyOnLoad(this);
        }
        public void PlayPressButtonSound() {
            audioSource.PlayOneShot(buttonPressClip,1.0f);
        }
        
    }
}
