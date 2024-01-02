using System.Collections.Generic;
using System.Linq;
using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours
{
    public class SetLanguagePreferenceController : MonoBehaviour
    {
        [SerializeField]
        private LevelPreferencesData  levelPreferencesData;

        [SerializeField]
        private List<LanguageToggleData> toggles;
        
        private LanguageToggleData currentToggle;

        private void Start()
        {
            currentToggle = new LanguageToggleData();
        }
        
        public void SetLanguageToLearn(string languageToLearn)
        {
            var languagesToLearnType = languageToLearn.Equals("Spanish") ? LanguageType.Spanish : LanguageType.French;
            
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