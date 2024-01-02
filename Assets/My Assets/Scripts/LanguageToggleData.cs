using System;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts
{
    [System.Serializable]
    public class LanguageToggleData
    {
        [SerializeField]
        private LanguagesToLearnType language;
        
        [SerializeField]
        private Toggle toggle;
        
        public LanguageToggleData()
        {
            language = LanguagesToLearnType.Spanish;
            toggle = null;
        }

        public LanguagesToLearnType Language
        {
            get { return language; }
            set { language = value; }
        }
        
        public Toggle Toggle
        {
            get { return toggle; }
            set { toggle = value; }
        }
    }
}