using My_Assets.Scripts.Behaviours;
using UnityEngine.SceneManagement;

namespace My_Assets.Scripts.Managers
{
    /// <summary>
    /// Manages the scene transitions
    /// </summary>
    public class SceneTransitionManager : DoNotDestroyOnLoadSingleton<SceneTransitionManager>
    {
        public void LoadGame()
        {
            SceneManager.LoadScene("LevelScene");
        }

        public void EndGame()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        public void LoadMainMenu()
        {
            SceneManager.LoadScene("LevelSetUpScene");
        }
    }
}