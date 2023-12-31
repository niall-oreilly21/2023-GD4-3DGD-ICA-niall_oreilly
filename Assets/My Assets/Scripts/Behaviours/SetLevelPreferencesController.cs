using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GD;
using My_Assets.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours
{
    public class SetLevelPreferencesController : MonoBehaviour
    {
        [SerializeField]
        private Slider countOfWordsToLearn;
    
        [SerializeField]
        private Slider countOfWordsToTest;

        [SerializeField]
        private InputField  tutorialSelected;
    
        [SerializeField]
        private LevelPreferencesData  levelPreferencesData;

        [SerializeField]
        private List<LanguageToggleData> toggles;
        
        private LanguageToggleData currentToggle;

        private void Start()
        {
            currentToggle = new LanguageToggleData();
        }

        void Update()
        {
            UpdateLevelPreferences();
        }
        public void SetLanguageToLearn(string languageToLearn)
        {
            var languagesToLearnType = languageToLearn.Equals("Spanish") ? LanguagesToLearnType.Spanish : LanguagesToLearnType.French;
            
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

                // Update the languageToLearn in levelPreferencesData
                
                levelPreferencesData.LanguageToLearn = languagesToLearnType;

                currentToggle = toggle;
            }
        }
        
        private void UpdateLevelPreferences()
        {
            levelPreferencesData.CountOfWordsToLearn = (int)countOfWordsToLearn.value;
            levelPreferencesData.CountOfWordsToTest = (int)countOfWordsToTest.value;
        }
    }
}
