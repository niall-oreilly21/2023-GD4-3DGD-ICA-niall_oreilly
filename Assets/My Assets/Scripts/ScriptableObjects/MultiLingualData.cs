using GD;
using UnityEngine;
using UnityEngine.Serialization;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameLevel", menuName = "DkIT/Scriptable Objects/Game/Language", order = 4)]
    public class MultiLingualData : BaseObjectData
    {
        [SerializeField]
        [Tooltip("Defines the English text and speech object")]
        private LanguageData englishLanguageData;
        
        [SerializeField]
        [Tooltip("Defines the Spanish text and speech object")]
        private LanguageData spanishLanguageData;
        
        [SerializeField]
        [Tooltip("Defines the French text and speech object")]
        private LanguageData frenchLanguageData;

        private LanguageData currentLanguageToLearnData;
        private bool wordIsToBeTested;
        
        public LanguageData EnglishLanguageData => englishLanguageData;
        public LanguageData CurrentLanguageToLearnData => currentLanguageToLearnData;

        public void SetCurrentLanguageToLearnData(LanguagesToLearnType languagesToLearn)
        {
            if (languagesToLearn.Equals(LanguagesToLearnType.Spanish))
            {
                currentLanguageToLearnData = spanishLanguageData;
            }
            else
            {
                currentLanguageToLearnData = frenchLanguageData;
            }
        }
        public bool WordIsToBeTested
        {
            get { return wordIsToBeTested; }
            set { wordIsToBeTested = value; }
        }
    }
}