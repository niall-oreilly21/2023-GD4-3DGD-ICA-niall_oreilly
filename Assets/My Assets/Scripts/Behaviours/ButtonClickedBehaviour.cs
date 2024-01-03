using My_Assets.Scripts.Managers;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours
{
    public class ButtonClickedBehaviour : MonoBehaviour
    {
        [SerializeField] 
        private AudioClip menuClickAudio;

        public void PlayButtonSound()
        {
            SoundManager.Instance.PlayOneShotSound(menuClickAudio);
        }

        public void SwitchBackgroundSound()
        {
            SoundManager.Instance.SwitchMenuAudio();
        }
    }
}