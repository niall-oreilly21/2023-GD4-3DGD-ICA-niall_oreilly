using System.Collections.Generic;
using System.Linq;
using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;
using GD;

namespace My_Assets.Scripts.Managers
{
    public class MyGameManager : Singleton<MyGameManager>
    {
        [SerializeField]
        private LevelPreferencesData levelPreferencesData;

        [SerializeField] 
        private Inventory inventory;
        
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

            levelPreferencesData.ResetLevelPreferences();
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
            //MyUIManager.Instance.DisplayInventoryEndCart(multiLingualDataList.Except(inventory.Contents.Values).ToList(), levelPreferencesData.CountOfWordsToLearn);
            MyUIManager.Instance.UnHideEndScreen();
            isPaused = true;
        }

        public void LoadMainMenu()
        {
            SoundManager.Instance.SwitchMenuAudio();
            SceneTransitionManager.Instance.LoadMainMenu();
        }
        
        private void SetUpUI()
        {
            List<string> shoppingList = new List<string>();
            foreach (MultiLingualData multiLingualData in multiLingualDataList)
            {
                shoppingList.Add(multiLingualData.CurrentLanguageToLearnData.LanguageText);
            }
            
            MyUIManager.Instance.SetCurrentLanguage(LanguageType.French);
            MyUIManager.Instance.SetPromptText();
            MyUIManager.Instance.DisplayShoppingList(shoppingList);

            if (levelPreferencesData.TutorialSelected)
            {
                MyUIManager.Instance.SetTutorialTextState(true);
            }
        }

        private void SetUpMultiLingualDataList()
        {
            FisherYatesAlgorithm.ShuffleList(multiLingualDataList);
            multiLingualDataList = multiLingualDataList.Take(levelPreferencesData.CountOfWordsToTest).ToList();
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