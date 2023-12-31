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

        private bool wordIsToBeTested = false;
        
        public LanguageData EnglishLanguageData => englishLanguageData;
        public LanguageData SpanishLanguageData => spanishLanguageData;
        public LanguageData FrenchLanguageData => frenchLanguageData;
        
        
        public bool WordIsToBeTested
        {
            get { return wordIsToBeTested; }
            set { wordIsToBeTested = value; }
        }
    }
}