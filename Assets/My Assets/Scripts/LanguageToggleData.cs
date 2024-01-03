using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace My_Assets.Scripts
{
    [System.Serializable]
    public class LanguageToggleData
    {
        [FormerlySerializedAs("language")] [SerializeField]
        private LanguageType language;
        
        [SerializeField]
        private Toggle toggle;
        
        public LanguageToggleData()
        {
            language = LanguageType.English;
            toggle = null;
        }

        public LanguageType Language
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