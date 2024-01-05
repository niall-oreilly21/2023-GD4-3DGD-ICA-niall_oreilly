using System.Collections.Generic;
using System.Linq;
using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;
using GD;
using My_Assets.Scripts.Enums;
using TMPro;

namespace My_Assets.Scripts.Managers
{
    public class MyGameManager : Singleton<MyGameManager>
    {
        [SerializeField]
        private LevelPreferencesData levelPreferencesData;

        [SerializeField] 
        private Inventory inventory;

        [SerializeField] 
        private TextMeshProUGUI endMenuTutorialButton;
        
        private List<MultiLingualData> multiLingualDataList;
        private bool isPaused;

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
            CheckGameOver();

            Time.timeScale = isPaused ? 0 : 1;
        }

        private void CheckGameOver()
        {
            
        }
    }
}