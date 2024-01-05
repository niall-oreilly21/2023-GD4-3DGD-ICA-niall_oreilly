using System.Collections.Generic;
using System.Linq;
using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;
using GD;
using TMPro;

namespace My_Assets.Scripts.Managers
{
    public class MyGameManager : Singleton<MyGameManager>
    {
        #region Fields

        [SerializeField]
        [Tooltip("Reference to the player's player's level preference.")]
        private LevelPreferencesData levelPreferencesData;

        [SerializeField] 
        [Tooltip("Reference to the player's inventory.")]
        private Inventory inventory;

        [SerializeField] 
        [Tooltip("The button used to exit the tutorial or play the game in the end menu.")]
        private TextMeshProUGUI endMenuTutorialButton;
        
        private List<MultiLingualData> multiLingualDataList;
        private bool isPaused;

        #endregion
        
        private void Start()
        {
            multiLingualDataList = new List<MultiLingualData>();
            StartLevel();
        }

        private void OnDestroy()
        {
            foreach (MultiLingualData multiLingualData in multiLingualDataList)
            {
                multiLingualData.WordIsToBeTested = false;
            }
        }

        private void StartLevel()
        {
            PrefabManager.Instance.LoadPrefabs(multiLingualDataList);
            SetUpMultiLingualDataList();
            SetUpUI();
            SoundManager.Instance.SwitchMenuAudio();
        }

        public void EndLevel()
        {
            if (levelPreferencesData.TutorialSelected)
            {
                endMenuTutorialButton.SetText("Play Game");
            }
            MyUIManager.Instance.DisplayEndMenu(multiLingualDataList.Except(inventory.Contents.Values).ToList(), levelPreferencesData.CountOfWordsToTest);
            isPaused = true;
        }

        /// <summary>
        /// Loads the main menu or the game scene based on tutorial selection.
        /// </summary>
        public void LoadMainMenu()
        {
            SoundManager.Instance.SwitchMenuAudio();
            
            if (levelPreferencesData.TutorialSelected)
            {
                levelPreferencesData.TutorialSelected = false;
                SceneTransitionManager.Instance.LoadGame();
            }
            else
            {
                levelPreferencesData.ResetLevelPreferences();
                SceneTransitionManager.Instance.LoadMainMenu();
            }
        }
        
        private void SetUpUI()
        {
            List<string> shoppingList = new List<string>();
            foreach (MultiLingualData multiLingualData in multiLingualDataList)
            {
                shoppingList.Add(multiLingualData.CurrentLanguageToLearnData.LanguageText);
            }
            
            MyUIManager.Instance.SetCurrentLanguage(levelPreferencesData.Language);
            MyUIManager.Instance.SetPromptText();
            MyUIManager.Instance.DisplayShoppingList(shoppingList);
            MyUIManager.Instance.SetTutorialTextState(levelPreferencesData.TutorialSelected);
        }

        /// <summary>
        /// Sets up the MultiLingualData list by shuffling and selecting words to be tested.
        /// </summary>
        private void SetUpMultiLingualDataList()
        {
            FisherYatesAlgorithm.ShuffleList(multiLingualDataList);
            multiLingualDataList = multiLingualDataList.Take(levelPreferencesData.CountOfWordsToTest).ToList();

            foreach (var multiLingualData in multiLingualDataList)
            {
                multiLingualData.WordIsToBeTested = true;
            }
        }

        private void Update()
        {
            Time.timeScale = isPaused ? 0 : 1;
        }
    }
}