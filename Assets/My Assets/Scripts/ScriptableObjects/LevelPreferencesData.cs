using GD;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelPreferences", menuName = "DkIT/Scriptable Objects/Game/LevelPreferences", order = 5)]
    public class LevelPreferencesData : BaseObjectData
    {
        private string languageToLearn = "";
        private int countOfWordsToLearn = 0;
        private int countOfWordsToTest = 0;
        private bool tutorialSelected = false;

        #region Properties

        public string LanguageToLearn
        {
            get { return languageToLearn; }
            set { languageToLearn = value; }
        }

        public int CountOfWordsToLearn
        {
            get { return countOfWordsToLearn; }
            set { countOfWordsToLearn = value; }
        }

        public int CountOfWordsToTest
        {
            get { return countOfWordsToTest; }
            set { countOfWordsToTest = value; }
        }

        public bool TutorialSelected
        {
            get { return tutorialSelected; }
            set { tutorialSelected = value; }
        }

        #endregion
    }

}