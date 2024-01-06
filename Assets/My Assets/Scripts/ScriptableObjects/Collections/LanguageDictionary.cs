using System.Collections.Generic;
using GD;
using My_Assets.Scripts.Enums;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects.Collections
{
    /// <summary>
    /// Scriptable object representing a language dictionary for the game, derived from ScriptableGameObject.
    /// </summary>
    [CreateAssetMenu(fileName = "LanguageDictionary", menuName = "DkIT/Scriptable Objects/Assets/Prefabs/LanguageDictionary", order = 3)]
    public class LanguageDictionary : ScriptableGameObject
    {
        #region Fields

        [Tooltip("Stores all the languages in the game")]
        public Dictionary<LanguageType, string> Languages;

        #endregion
        
        /// <summary>
        /// Retrieves the label associated with the specified language type.
        /// </summary>
        /// <param name="languageType">The language type to retrieve the label for.</param>
        /// <returns>The label corresponding to the given language type.</returns>
        public string GetCurrentLanguageLabel(LanguageType languageType)
        {
            if (Languages.TryGetValue(languageType, out string label))
            {
                return label;
            }
            Debug.LogWarning($"Label for language type {languageType} not found.");
            return string.Empty;
        }

        /// <summary>
        /// Retrieves the language type associated with the specified label.
        /// </summary>
        /// <param name="languageLabel">The label to retrieve the language type for.</param>
        /// <returns>The language type corresponding to the given label.</returns>
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