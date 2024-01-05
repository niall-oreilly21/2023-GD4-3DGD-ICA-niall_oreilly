using GD;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.Singleton
{
    /// <summary>
    /// Singleton MonoBehaviour that persists through scene changes and should not be destroyed on load.
    /// </summary>
    /// <typeparam name="T">Type of the singleton.</typeparam>
    public class DoNotDestroyOnLoadSingleton<T> : Singleton<T> where T : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        protected BoolVariable isInitialised;

        #endregion

        private void Awake()
        {
            // Do not destroy the singleton on load
            DontDestroyOnLoad(gameObject);
        }
    }
}