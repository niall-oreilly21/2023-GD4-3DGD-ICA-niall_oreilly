using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours.LevelPreferences
{
    /// <summary>
    /// Unity MonoBehaviour for managing shop preferences related to word learning and testing.
    /// </summary>
    public class SetShopPreferencesController : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        [Tooltip("Data structure holding level-specific preferences.")]
        private LevelPreferencesData  levelPreferencesData;
        
        [SerializeField]
        [Tooltip("Slider for setting the count of words to learn.")]
        private Slider countOfWordsToLearn;
    
        [SerializeField]
        [Tooltip("Slider for setting the count of words to test.")]
        private Slider countOfWordsToTest;
        #endregion

        public void SetCountOfWordsToLearnPreference()
        {
            levelPreferencesData.CountOfWordsToLearn = (int)countOfWordsToLearn.value;
        }

        public void SetCountOfWordsToTestPreference()
        {
            levelPreferencesData.CountOfWordsToTest = (int)countOfWordsToTest.value;
        }
    }
}
