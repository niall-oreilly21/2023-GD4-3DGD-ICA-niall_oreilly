using System.Collections.Generic;
using GD;
using UnityEngine;

namespace My_Assets.Scripts
{
    [CreateAssetMenu(fileName = "LanguageDictionary", menuName = "DkIT/Scriptable Objects/Assets/Prefabs/LanguageDictionary", order = 3)]
    public class LanguageDictionary : ScriptableGameObject
    {
        [Tooltip("Stores all the languages in the game")]
        public Dictionary<LanguageType, string> Languages;

        public string GetCurrentLanguageLabel(LanguageType languageType)
        {
            if (Languages.TryGetValue(languageType, out string label))
            {
                return label;
            }
            Debug.LogWarning($"Label for language type {languageType} not found.");
            return string.Empty;
        }

        public LanguageType GetCurrentLanguageLabel(string languageLabel)
        {
            foreach (var keyPair in Languages)
            {
                if (keyPair.Value == languageLabel)
                {
                    return keyPair.Key;
                }
            }

            Debug.LogWarning($"Language type for label {languageLabel} not found.");
            return LanguageType.English; // or another default value
        }
        
    }
}