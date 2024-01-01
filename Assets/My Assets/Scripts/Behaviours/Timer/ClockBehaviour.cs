using My_Assets.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.Timer
{
    public class ClockBehaviour : TimerBehaviour
    {
        [SerializeField] 
        private ClockData clockData;
        
        [SerializeField]
        private int timeLeftBeforeColourChanges;
        
        [SerializeField]
        private Color endColor;
        
        private TextMeshProUGUI clockText;
        private Color baseColor;
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