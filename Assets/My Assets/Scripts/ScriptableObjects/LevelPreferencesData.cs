using GD;
using My_Assets.Scripts.Enums;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelPreferences", menuName = "DkIT/Scriptable Objects/Game/LevelPreferences", order = 5)]
    public class LevelPreferencesData : BaseObjectData
    {
        private LanguageType language = LanguageType.Spanish;
        private int countOfWordsToLearn = 1;
        private int countOfWordsToTest = 1;
        private bool tutorialSelected = false;

        public void ResetLevelPreferences()
        {
            language = LanguageType.Spanish;
            countOfWordsToTest = 1;
            countOfWordsToLearn = 1;
        }

        #region Properties

        public LanguageType Language
        {
            get { return language; }
            set { language = value; }
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