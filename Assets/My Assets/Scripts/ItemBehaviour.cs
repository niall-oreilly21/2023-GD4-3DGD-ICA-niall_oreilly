using System;
using GD;
using My_Assets.Scripts.ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;

namespace My_Assets.Scripts
{
    public class ItemBehaviour : MonoBehaviour
    {
        [SerializeField]
        private MultiLingualObject multiLingualObject;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(Enum recordingToPlay)
        {
            if (recordingToPlay.Equals(RecordedSoundType.ENGLISH))
            {
                audioSource.clip = multiLingualObject.EnglishLanguageObject.TextToSpeech;
                audioSource.Play();
            }
        }
    }
}