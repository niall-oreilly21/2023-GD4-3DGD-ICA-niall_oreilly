using GD;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.Timer
{
    /// <summary>
    /// Scriptable Object representing clock data for time-related game mechanics.
    /// </summary>
    [CreateAssetMenu(fileName = "GameLevel", menuName = "DkIT/Scriptable Objects/Game/Clock", order = 3)]
    public class ClockData : BaseObjectData
    {
        #region Fields

        [SerializeField]
        [Tooltip("The initial minutes value for the clock.")]
        private int minutes;
    
        [SerializeField]
        [Tooltip("The initial seconds value for the clock.")]
        private int seconds;

        #endregion
        
        #region Properties

        public int Minutes
        {
            get => minutes;
            set => minutes = value;
        }
        
        public int Seconds
        {
            get => seconds;
            set => seconds = value;
        }

        #endregion
        
        /// <summary>
        /// Calculates and returns the total time in seconds represented by the clock.
        /// </summary>
        /// <returns>The total time in seconds.</returns>
        public float GetTotalSeconds()
        {
            return minutes * 60.0f + seconds;
        }
    }
}