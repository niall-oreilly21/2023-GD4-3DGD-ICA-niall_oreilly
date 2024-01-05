using My_Assets.Scripts.Managers;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.UI
{
    /// <summary>
    /// Unity MonoBehaviour for handling button clicks and playing associated audio.
    /// </summary>
    public class ButtonClickedBehaviour : MonoBehaviour
    {
        #region Fields

        [SerializeField] private AudioClip menuClickAudio;

        #endregion

        /// <summary>
        /// Plays the assigned button click sound using the SoundManager.
        /// </summary>
        public void PlayButtonSound()
        {
            SoundManager.Instance.PlayOneShotSound(menuClickAudio);
        }
    }
}