using My_Assets.Scripts.Behaviours.Player;
using My_Assets.Scripts.Behaviours.Timer;
using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours.LevelPreferences
{
    /// <summary>
    /// Unity MonoBehaviour for managing clock preferences via sliders.
    /// </summary>
    public class SetClockPreferencesController : MonoBehaviour
    {
        #region Fields
        
        [SerializeField]
        [Tooltip("Data structure holding clock preferences.")]
        private ClockData clockData;
        
        [SerializeField] 
        [Tooltip("Slider for selecting minutes.")]
        private Slider minutesSlider;

        [SerializeField] 
        [Tooltip("Slider for selecting seconds.")]
        private Slider secondsSlider;
        
        #endregion
        
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