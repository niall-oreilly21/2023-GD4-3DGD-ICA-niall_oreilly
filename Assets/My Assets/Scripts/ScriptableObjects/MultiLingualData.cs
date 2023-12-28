using GD;
using UnityEngine;
using UnityEngine.Serialization;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameLevel", menuName = "DkIT/Scriptable Objects/Game/Language", order = 4)]
    public class MultiLingualData : BaseObjectData
    {
        [FormerlySerializedAs("englishLanguageObject")]
        [SerializeField]
        [Tooltip("Defines the English text and speech object")]
        private LanguageData englishLanguageData;
        
        [FormerlySerializedAs("spanishLanguageObject")]
        [SerializeField]
        [Tooltip("Defines the Spanish text and speech object")]
        private LanguageData spanishLanguageData;
        
        [FormerlySerializedAs("frenchLanguageObject")]
        [SerializeField]
        [Tooltip("Defines the French text and speech object")]
        private LanguageData frenchLanguageData;
        
        public LanguageData EnglishLanguageData => englishLanguageData;
        public LanguageData SpanishLanguageData => spanishLanguageData;
        public LanguageData FrenchLanguageData => frenchLanguageData;
    }
}