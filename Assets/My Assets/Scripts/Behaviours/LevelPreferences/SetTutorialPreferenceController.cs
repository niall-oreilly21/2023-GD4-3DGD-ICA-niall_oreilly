using System;
using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours
{
    public class SetTutorialPreferenceController : MonoBehaviour
    {
        [SerializeField] 
        private LevelPreferencesData levelPreferencesData;

        private Toggle toggle;

        private void Start()
        {
            toggle = GetComponent<Toggle>();
        }

        public void SetTutorialPreference()
        {
            levelPreferencesData.TutorialSelected = toggle.isOn;
        }
    }
}