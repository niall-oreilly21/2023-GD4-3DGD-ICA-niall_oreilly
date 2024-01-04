using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours.LevelPreferences
{
    /// <summary>
    /// Unity MonoBehaviour for managing tutorial preferences using a Toggle component.
    /// </summary>
    public class SetTutorialPreferenceController : MonoBehaviour
    {
        #region Fields
        [SerializeField] 
        [Tooltip("Data structure holding level-specific preferences.")]
        private LevelPreferencesData levelPreferencesData;

        private Toggle toggle;
        #endregion


        private void Start()
        {
            toggle = GetComponent<Toggle>();
        }

        public void SetTutorialPreference()
        {
            levelPreferencesData.TutorialSelected = toggle.isOn;
        }
    }
}