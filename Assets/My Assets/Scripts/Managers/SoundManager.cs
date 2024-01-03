using System;
using My_Assets.Scripts.Behaviours;
using UnityEngine;

namespace My_Assets.Scripts.Managers
{
    public class SoundManager : DoNotDestroyOnLoadSingleton<SoundManager>
    {
        [SerializeField] 
        private AudioClip menuAudio;
        
        [SerializeField] 
        private AudioClip gameBacktrackAudio;
        
        [SerializeField] 
        private AudioSource[] audioSources;

        private bool isMenuAudioPlaying;

        private void Start()
        {
            isMenuAudioPlaying = true;
            
            audioSources = GetComponents<AudioSource>();

            if (audioSources == null || audioSources.Length < 2)
            {
                Debug.LogError("Two AudioSource components not found on the same GameObject as SoundManager.");
                return;
            }
            
            SwitchMenuAudio();
        }

        public void PlayOneShotSound(AudioClip audioClip)
        {
            audioSources[(int)AudioSourceType.GameEvent].PlayOneShot(audioClip);
        }

        public void SwitchMenuAudio()
        {
            if (isMenuAudioPlaying)
            {
                audioSources[(int)AudioSourceType.Menu].clip = gameBacktrackAudio;
            }
            else
            {
                audioSources[(int)AudioSourceType.Menu].clip = menuAudio;
            }
            audioSources[(int)AudioSourceType.Menu].Play();
            isMenuAudioPlaying = !isMenuAudioPlaying;
        }

        public void StopBackgroundAudio()
        {
            audioSources[(int)AudioSourceType.Menu].Stop();
        }
    }
}