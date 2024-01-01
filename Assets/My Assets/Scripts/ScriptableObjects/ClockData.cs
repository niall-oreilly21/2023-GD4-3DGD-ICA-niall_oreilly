using GD;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameLevel", menuName = "DkIT/Scriptable Objects/Game/Clock", order = 3)]
    public class ClockData : BaseObjectData
    {
        [SerializeField]
        private int minutes;
        
        [SerializeField]
        private int seconds;

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

        public float GetTotalSeconds()
        {
            return minutes * 60.0f + seconds;
        }
    }
}