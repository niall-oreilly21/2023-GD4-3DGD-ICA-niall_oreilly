using UnityEngine.SceneManagement;

namespace GD
{
    /// <summary>
    /// Manages the scene transitions
    /// </summary>
    public class SceneTransitionManager : Singleton<SceneTransitionManager>
    {
        public void LoadGame()
        {
            SceneManager.LoadScene("CA_outline");
        }
    }
}