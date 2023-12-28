using Sirenix.OdinInspector;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [System.Serializable]
    public class LanguageData
    {
        [Tooltip("An AudioSource for the speech of the text")]
        [Searchable]
        public AudioClip textToSpeech;

        [SerializeField]
        [Tooltip("The text of the object in a language")]
        private string languageText;

        public AudioClip TextToSpeech => textToSpeech;
        public string LanguageText => languageText;

        // public void PlayTextAudio()
        // {
        //     if (textToSpeech != null)
        //     {
        //         textToSpeech.Play();
        //     }
        //     else
        //     {
        //         Debug.LogWarning("No AudioSource assigned to the TextToSpeech field.");
        //     }
        // }
    }
}