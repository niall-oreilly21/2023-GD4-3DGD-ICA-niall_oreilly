using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours
{
    public class SetTutorialPreferenceController : MonoBehaviour
    {
        [SerializeField] 
        private LevelPreferencesData levelPreferencesData;
        
        [SerializeField] 
        private Toggle tutorialToggle;

        public void SetTutorial(bool isTutorial)
        {
            levelPreferencesData.TutorialSelected = isTutorial;
        }
    }
}