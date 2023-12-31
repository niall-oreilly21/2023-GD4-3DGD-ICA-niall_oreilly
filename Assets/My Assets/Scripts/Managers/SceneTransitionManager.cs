using System.Collections;
using My_Assets.Scripts.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GD
{
    /// <summary>
    /// Manages the scene transitions
    /// </summary>
    public class SceneTransitionManager : DoNotDestroyOnLoadBehaviour
    {
        public void LoadGame()
        {
            SceneManager.LoadScene("CA_outline");
        }

        public void EndGame()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }
    }
}