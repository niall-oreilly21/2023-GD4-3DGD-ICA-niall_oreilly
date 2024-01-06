using My_Assets.Scripts.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects.Languages
{
    /// <summary>
    /// Serializable class representing the data of a language.
    /// </summary>
    [System.Serializable]
    public class LanguageData
    {
        #region Fields

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

        #endregion

        #region Properties

        public LanguageType LanguageType => languageType;
        public AudioClip TextToSpeech => textToSpeech;
        public string LanguageText => languageText;

        #endregion

    }
}