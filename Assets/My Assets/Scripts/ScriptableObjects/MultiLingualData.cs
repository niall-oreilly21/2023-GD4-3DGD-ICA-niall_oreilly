using System.Collections.Generic;
using System.Linq;
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
        [Tooltip("Defines the Languages that can be learnt")]
        private List<LanguageData> languageDatas;

        private LanguageData currentLanguageToLearnData;
        private bool wordIsToBeTested;
        
        public LanguageData EnglishLanguageData => englishLanguageData;
        public LanguageData CurrentLanguageToLearnData => currentLanguageToLearnData;

        public void SetCurrentLanguageToLearnData(LanguageType languageType)
        {
            foreach (var languageData in languageDatas.Where(languageData => languageData.LanguageType.Equals(languageType)))
            {
                currentLanguageToLearnData = languageData;
            }
        }
        public bool WordIsToBeTested
        {
            get { return wordIsToBeTested; }
            set { wordIsToBeTested = value; }
        }
    }
}