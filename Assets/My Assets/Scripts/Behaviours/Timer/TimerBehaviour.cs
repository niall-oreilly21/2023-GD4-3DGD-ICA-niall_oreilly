using GD;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.Timer
{
    /// <summary>
    /// Abstract base class for timer behaviors, handling countdown logic.
    /// </summary>
    public abstract class TimerBehaviour : MonoBehaviour
    {
        #region Fields
        [SerializeField] 
        [Tooltip("Event triggered when the timer completes.")]
        protected GameEvent timerEndEvent;
        
        private float totalSeconds;
        protected float totalTime;
        private float elapsedTime;
        #endregion

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