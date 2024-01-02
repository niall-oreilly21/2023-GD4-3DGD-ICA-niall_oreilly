using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace My_Assets.Scripts.ScriptableObjects
{
    [System.Serializable]
    public class LanguageData
    {
        [SerializeField]
        [Tooltip("The language")]
        private LanguageType languageType;
        
        [SerializeField]
        [Tooltip("An AudioSource for the speech of the text")]
        [Searchable]
        private AudioClip textToSpeech;

        [SerializeField]
        [Tooltip("The text of the object in a language")]
        private string languageText;
        
        public LanguageType LanguageType => languageType;
        public AudioClip TextToSpeech => textToSpeech;
        public string LanguageText => languageText;
    }
}