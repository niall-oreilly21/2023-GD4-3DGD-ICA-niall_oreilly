using GD;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours
{
    public class DoNotDestroyOnLoadSingleton<T> : Singleton<T> where T : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}