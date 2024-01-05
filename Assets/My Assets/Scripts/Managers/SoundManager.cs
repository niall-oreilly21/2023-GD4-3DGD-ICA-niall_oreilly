using System;
using My_Assets.Scripts.Behaviours;
using My_Assets.Scripts.Behaviours.Singleton;
using My_Assets.Scripts.Enums;
using UnityEngine;

namespace My_Assets.Scripts.Managers
{
    /// <summary>
    /// Manages audio playback in the game, including background music and one-shot sounds.
    /// </summary>
    public class SoundManager : DoNotDestroyOnLoadSingleton<SoundManager>
    {
        #region Fields

        [SerializeField] 
        [Tooltip("The audio clip for the menu.")]
        private AudioClip menuAudio;
        
        [SerializeField] 
        [Tooltip("The audio clip for the game's backtrack.")]
        private AudioClip gameBacktrackAudio;
        
        private AudioSource[] audioSources;
        private bool isMenuAudioPlaying;

        #endregion

        private void Start()
        {
            isMenuAudioPlaying = false;
            audioSources = GetComponents<AudioSource>();
            if (audioSources == null || audioSources.Length < 2)
            {
                Debug.LogError("Two AudioSource components not found on the same GameObject as SoundManager.");
                return;
            }

            if (isInitialised.Value)
            {
                return;
            }

            isInitialised.Value = true;
            SwitchMenuAudio();
        }

        private void OnDisable()
        {
            isInitialised.Value = false;
        }

        /// <summary>
        /// Plays a one-shot sound using the specified AudioClip.
        /// </summary>
        /// <param name="audioClip">The AudioClip to play.</param>
        public void PlayOneShotSound(AudioClip audioClip)
        {
            audioSources[(int)AudioSourceType.GameEvent].PlayOneShot(audioClip);
        }

        /// <summary>
        /// Switches between menu audio and game backtrack audio for the background music.
        /// </summary>
        public void SwitchMenuAudio()
        {
            isMenuAudioPlaying = !isMenuAudioPlaying;

            if (isMenuAudioPlaying)
            {
                audioSources[(int)AudioSourceType.Background].clip = menuAudio;
            }
            else
            {
                audioSources[(int)AudioSourceType.Background].clip = gameBacktrackAudio;
            }
            audioSources[(int)AudioSourceType.Background].Play();
        }
    }
}