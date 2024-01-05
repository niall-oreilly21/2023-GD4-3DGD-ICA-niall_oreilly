using System;
using My_Assets.Scripts.Behaviours;
using My_Assets.Scripts.Enums;
using UnityEngine;

namespace My_Assets.Scripts.Managers
{
    public class SoundManager : DoNotDestroyOnLoadSingleton<SoundManager>
    {
        [SerializeField] 
        private AudioClip menuAudio;
        
        [SerializeField] 
        private AudioClip gameBacktrackAudio;
        
        private AudioSource[] audioSources;
        private bool isMenuAudioPlaying;
        private bool setIsInitialised = true;

        private void Start()
        {
            isMenuAudioPlaying = false;
            audioSources = GetComponents<AudioSource>();
            if (audioSources == null || audioSources.Length < 2)
            {
                Debug.LogError("Two AudioSource components not found on the same GameObject as SoundManager.");
                return;
            }

            if (setIsInitialised)
            {
                isInitialised.Value = false;
            }

            setIsInitialised = false;

            
            if (isInitialised.Value)
            {
                return;
            }

            isInitialised.Value = true;
            SwitchMenuAudio();
        }


        public void PlayOneShotSound(AudioClip audioClip)
        {
            audioSources[(int)AudioSourceType.GameEvent].PlayOneShot(audioClip);
        }

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

        private void StopBackgroundAudio()
        {
            audioSources[(int)AudioSourceType.Background].Stop();
        }
    }
}