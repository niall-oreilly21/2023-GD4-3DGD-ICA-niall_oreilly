using TMPro;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.Timer
{
    public class ClockBehaviour : TimerBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI clockText;
        
        [SerializeField]
        private Color baseColor;
        
        [SerializeField]
        private int timeLeftBeforeColourChanges;
        
        [SerializeField]
        private Color endColor;

        protected override void Start()
        {
            clockText = GetComponent<TextMeshProUGUI>();
            baseColor = clockText.color;
            base.Start();
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
            timerEndEvent.Raise();
        }

        private void ChangeTimerColor()
        {
            if (totalTime <= timeLeftBeforeColourChanges && totalTime > 0f)
            {
                clockText.color = Color.red;
            }
        }
        
        private void UpdateClock()
        {
            clockText.text = string.Format("{0:0}:{1:00}", GetCurrentMinutes(), GetCurrentSeconds());
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