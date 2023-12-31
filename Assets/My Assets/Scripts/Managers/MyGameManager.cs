using System;
using System.Collections.Generic;
using System.Linq;
using My_Assets.Scripts.Behaviours;
using My_Assets.Scripts.ScriptableObjects;
using Sirenix.Reflection.Editor;
using Unity.VisualScripting;
using UnityEngine;

namespace My_Assets.Scripts.Managers
{
    public class MyGameManager : GD.Singleton<MyGameManager>
    {
        [SerializeField]
        private LevelPreferencesData levelPreferencesData;

        [SerializeField] 
        private ItemPrefabDictionary itemPrefabDictionary;
        private List<MultiLingualData> multiLingualDataList;

        private void Start()
        {
            multiLingualDataList = new List<MultiLingualData>();
            
            levelPreferencesData.CountOfWordsToLearn = 2;
            levelPreferencesData.CountOfWordsToTest = 2;
            levelPreferencesData.LanguageToLearn = LanguagesToLearnType.Spanish;
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
            LoadPrefabs();
            SetUpMultiLingualDataList();
            SetUpUI();
        }
        
        private void SetUpUI()
        {
            List<string> shoppingList = new List<string>();

            string wordToTest = "";
            foreach (MultiLingualData multiLingualData in multiLingualDataList)
            {
                wordToTest = levelPreferencesData.LanguageToLearn switch
                {
                    LanguagesToLearnType.French => multiLingualData.FrenchLanguageData.LanguageText,
                    LanguagesToLearnType.Spanish => multiLingualData.SpanishLanguageData.LanguageText,
                    _ => wordToTest
                };
                shoppingList.Add(wordToTest);
            }
            
            MyUIManager.Instance.DisplayShoppingList(shoppingList);
        }

        public void LoadPrefabs()
        {
            itemPrefabDictionary.LoadPrefabs(levelPreferencesData.CountOfWordsToLearn);
            
            // Instantiate all prefabs in the dictionary
            foreach (GameObject prefab in itemPrefabDictionary.Prefabs.Values)
            {
                ItemBehaviour itemBehaviour = prefab.GetComponent<ItemBehaviour>();
                
                multiLingualDataList.Add(itemBehaviour.MultiLingualData);
                Instantiate(prefab, itemBehaviour.StartPosition, Quaternion.identity);
            }
        }
        
        private void SetUpMultiLingualDataList()
        {
            FisherYatesAlgorithm.ShuffleList(multiLingualDataList);
            multiLingualDataList = multiLingualDataList.Take(levelPreferencesData.CountOfWordsToTest).ToList();
        }

        public void LoadPrefab(string itemToAdd)
        {
            if (itemPrefabDictionary.Prefabs.TryGetValue(itemToAdd, out GameObject prefab))
            {
                Vector3 startPosition = prefab.GetComponent<ItemBehaviour>().StartPosition;
                Instantiate(prefab, startPosition, Quaternion.identity);
            }
            else
            {
                Debug.LogWarning($"Prefab with key '{itemToAdd}' not found in the dictionary.");
            }
        }

        private void Update()
        {
            CheckGameOver();
        }

        private void CheckGameOver()
        {
            
        }
    }
}