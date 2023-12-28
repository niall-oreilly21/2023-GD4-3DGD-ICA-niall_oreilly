using Sirenix.OdinInspector;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [System.Serializable]
    public struct LanguageObject
    {
        [Tooltip("An Audio Clip for the speech of the text")]
        [Searchable]
        public AudioClip textToSpeech;
        
        [SerializeField]
        [Tooltip("The text of the the object in a language")]
        private string languageText;
        
        public AudioClip TextToSpeech => textToSpeech;
        public string LanguageText => languageText;
    }
}