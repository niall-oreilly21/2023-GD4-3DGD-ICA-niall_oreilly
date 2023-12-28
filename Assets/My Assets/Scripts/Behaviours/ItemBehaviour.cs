using System;
using GD;
using My_Assets.Scripts.ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace My_Assets.Scripts
{
    public class ItemBehaviour : MonoBehaviour
    {
        [FormerlySerializedAs("multiLingualObject")] [SerializeField]
        private MultiLingualData multiLingualData;
        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlaySound(Enum recordingToPlay)
        {
            if (recordingToPlay.Equals(RecordedSoundType.ENGLISH))
            {
                audioSource.clip = multiLingualData.EnglishLanguageData.TextToSpeech;
                audioSource.Play();
            }
        }
    }
}