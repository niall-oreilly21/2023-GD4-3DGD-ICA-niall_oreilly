using System.Collections.Generic;
using System.Linq;
using GD;
using My_Assets.Scripts.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects.Languages
{
    /// <summary>
    /// Scriptable object representing multilingual data for a game level, derived from BaseObjectData.
    /// Includes information such as icon, English language data, a list of languages that can be learned, and related properties.
    /// </summary>
    [CreateAssetMenu(fileName = "GameLevel", menuName = "DkIT/Scriptable Objects/Game/Language", order = 4)]
    public class MultiLingualData : BaseObjectData
    {
        #region Fields

        [SerializeField]
        [Tooltip("Defines the icon of the object")]
        [Searchable]
        private Sprite icon;
        
        [SerializeField]
        [Tooltip("Defines the English text and speech object")]
        private LanguageData englishLanguageData;
        
        [SerializeField]
        [Tooltip("Defines the Languages that can be learnt")]
        private List<LanguageData> languageDatas;

        private LanguageData currentLanguageToLearnData;
        private bool wordIsToBeTested;

        #endregion
        
        #region Properties
        
        public Sprite Icon => icon;
        public LanguageData EnglishLanguageData => englishLanguageData;
        public LanguageData CurrentLanguageToLearnData => currentLanguageToLearnData;

        public bool WordIsToBeTested
        {
            get { return wordIsToBeTested; }
            set { wordIsToBeTested = value; }
        }

        #endregion

        /// <summary>
        /// Sets the current language data to be learned based on the specified language type.
        /// </summary>
        /// <param name="languageType">The language type to set as the current language to learn.</param>
        public void SetCurrentLanguageToLearnData(LanguageType languageType)
        {
            foreach (var languageData in languageDatas.Where(languageData => languageData.LanguageType.Equals(languageType)))
            {
                currentLanguageToLearnData = languageData;
            }
        }

    }
}