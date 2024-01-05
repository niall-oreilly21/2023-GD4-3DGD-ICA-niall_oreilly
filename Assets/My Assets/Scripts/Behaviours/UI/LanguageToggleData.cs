using System;
using My_Assets.Scripts.Enums;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace My_Assets.Scripts
{
    /// <summary>
    /// Serializable class representing language toggle data, used for language selection.
    /// </summary>
    [System.Serializable]
    public class LanguageToggleData
    {
        #region Fields

        [SerializeField]
        [Tooltip("The language associated with the toggle.")]
        private LanguageType language;

        [SerializeField]
        [Tooltip("The UI toggle associated with the language.")]
        private Toggle toggle;

        #endregion

        #region Properties
        
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
        
        #endregion
       
    }
}