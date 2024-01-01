using GD;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.Timer
{
    public abstract class TimerBehaviour : MonoBehaviour
    {
        [SerializeField] 
        protected GameEvent timerEndEvent;
        
        private float totalSeconds;
        protected float totalTime;
        private float elapsedTime;

        protected virtual void Update()
        {
            elapsedTime += Time.deltaTime;
            totalTime = Mathf.Max(totalSeconds - elapsedTime, 0f);
            CheckTimerComplete();
        }

        protected void StartTimer(float interval)
        {
            totalSeconds = interval;
            elapsedTime = 0f;
            totalTime = 0f;
        }

        private void CheckTimerComplete()
        {
            if (totalTime <= 0f)
            {
                HandleTimerComplete();
            }
        }
        protected abstract void HandleTimerComplete();
    }
}