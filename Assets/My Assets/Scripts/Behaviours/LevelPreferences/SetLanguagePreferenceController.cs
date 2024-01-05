using System.Collections.Generic;
using System.Linq;
using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.LevelPreferences
{
    /// <summary>
    /// Unity MonoBehaviour for managing language preferences and toggles.
    /// </summary>
    public class SetLanguagePreferenceController : MonoBehaviour
    {
        #region Fields
        
        [SerializeField]
        [Tooltip("Data structure holding level-specific preferences.")]
        private LevelPreferencesData  levelPreferencesData;
        
        [SerializeField] 
        [Tooltip("Dictionary containing language-specific data.")]
        private LanguageDictionary languageDictionary;

        [SerializeField]
        [Tooltip("List of language toggle data for user selection.")]
        private List<LanguageToggleData> toggles;

        private LanguageToggleData currentToggle;
        
        #endregion
        
        private void Start()
        {
            currentToggle = new LanguageToggleData();
        }
        
        public void SetLanguageToLearn(string languageToLearn)
        {
            var languagesToLearnType = languageDictionary.GetCurrentLanguageLabel(languageToLearn);
            
            if (currentToggle.Language.Equals(languagesToLearnType))
            {
                return;
            }

            foreach (var toggle in toggles.Where(toggle => toggle.Language.Equals(languagesToLearnType)))
            {
                // Disable the currentToggleSelected
                if (currentToggle.Toggle != null)
                {
                    currentToggle.Toggle.isOn = false;
                }

                levelPreferencesData.Language = languagesToLearnType;
                currentToggle = toggle;
            }
        }
    }
}