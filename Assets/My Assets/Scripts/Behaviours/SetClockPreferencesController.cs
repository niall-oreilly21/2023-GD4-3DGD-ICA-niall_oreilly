using System;
using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours
{
    public class SetClockPreferencesController : MonoBehaviour
    {
        [SerializeField]
        private ClockData clockData;

        [SerializeField] 
        private Slider minutesSlider;

        [SerializeField] 
        private Slider secondsSlider;

        private void Update()
        {
            UpdateClockPreferences();
        }
        private void UpdateClockPreferences()
        {
            clockData.Minutes = (int)minutesSlider.value;
            clockData.Seconds = (int)secondsSlider.value;
        }
    }
}