using GD;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameLevel", menuName = "DkIT/Scriptable Objects/Game/Language", order = 4)]
    public class MultiLingualObject : BaseObjectData
    {
        [SerializeField]
        [Tooltip("Defines the English text and speech object")]
        private LanguageObject englishLanguageObject;
        
        [SerializeField]
        [Tooltip("Defines the Spanish text and speech object")]
        private LanguageObject spanishLanguageObject;
        
        [SerializeField]
        [Tooltip("Defines the French text and speech object")]
        private LanguageObject frenchLanguageObject;
        
        public LanguageObject EnglishLanguageObject => englishLanguageObject;
        public LanguageObject SpanishLanguageObject => spanishLanguageObject;
        public LanguageObject FrenchLanguageObject => frenchLanguageObject;
    }
}