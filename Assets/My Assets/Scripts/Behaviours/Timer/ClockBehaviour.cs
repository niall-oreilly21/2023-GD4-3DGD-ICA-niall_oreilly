using My_Assets.Scripts.ScriptableObjects;
using My_Assets.Scripts.ScriptableObjects.Timer;
using TMPro;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.Timer
{
    /// <summary>
    /// Unity MonoBehaviour for displaying a countdown timer with color changes.
    /// </summary>
    public class ClockBehaviour : TimerBehaviour
    {
        #region Fields
        [SerializeField] 
        [Tooltip("Data structure holding clock-related information.")]
        private ClockData clockData;
        
        [SerializeField]
        [Tooltip("Time threshold before changing text color.")]
        private int timeLeftBeforeColourChanges;
        
        [SerializeField]
        [Tooltip("Color to change to when nearing the end of the timer.")]
        private Color endColor;
        
        private TextMeshProUGUI clockText;
        private Color baseColor;
        #endregion
        
        void Start()
        {
            clockText = GetComponent<TextMeshProUGUI>();
            baseColor = clockText.color;
            StartTimer(clockData.GetTotalSeconds());
        }

        protected override void Update()
        {
            base.Update();
            ChangeTimerColor();
            UpdateClock();
        }

        protected override void HandleTimerComplete()
        {
            clockText.color = baseColor;
            gameObject.SetActive(false);
            timerEndEvent.Raise();
        }

        private void ChangeTimerColor()
        {
            if (totalTime <= timeLeftBeforeColourChanges && totalTime > 0f)
            {
                clockText.color = endColor;
            }
        }
        
        private void UpdateClock()
        {
            clockText.SetText($"{GetCurrentMinutes():0}:{GetCurrentSeconds():00}");
        }
        
        private float GetCurrentMinutes()
        {
            return Mathf.Floor(totalTime / 60);
        }

        private float GetCurrentSeconds()
        {
            return totalTime % 60;
        }
    }
}