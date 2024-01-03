using GD;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours
{
    public class DoNotDestroyOnLoadSingleton<T> : Singleton<T> where T : MonoBehaviour
    {

        [SerializeField]
        protected BoolVariable isInitialised;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}