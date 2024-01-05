using My_Assets.Scripts.Behaviours.Singleton;
using UnityEngine.SceneManagement;

namespace My_Assets.Scripts.Managers
{
    /// <summary>
    /// Manages the scene transitions
    /// TODO Should use Game Scriptable object for storing scenes
    /// </summary>
    public class SceneTransitionManager : DoNotDestroyOnLoadSingleton<SceneTransitionManager>
    {
        /// <summary>
        /// Loads the main game scene.
        /// </summary>
        public void LoadGame()
        {
            SceneManager.LoadScene("LevelScene");
        }

        /// <summary>
        /// Ends the game, either by quitting the application or stopping play mode in the editor.
        /// </summary>
        public void EndGame()
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        }

        /// <summary>
        /// Loads the main menu scene.
        /// </summary>
        public void LoadMainMenu()
        {
            SceneManager.LoadScene("LevelSetUpScene");
        }
    }
}