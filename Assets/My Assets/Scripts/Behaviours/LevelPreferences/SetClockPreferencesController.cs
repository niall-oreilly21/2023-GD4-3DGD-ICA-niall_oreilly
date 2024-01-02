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

        public void SetMinutePreference()
        {
            clockData.Minutes = (int)minutesSlider.value;
        }

        public void SetSecondPreference()
        {
            clockData.Seconds = (int)secondsSlider.value;
        }
    }
}