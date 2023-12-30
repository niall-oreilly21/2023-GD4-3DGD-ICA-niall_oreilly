using System;
using System.Collections.Generic;
using System.Linq;
using GD;
using My_Assets.Scripts.ScriptableObjects;
using Sirenix.Reflection.Editor;
using UnityEngine;

namespace My_Assets.Scripts.Managers
{
    public class MyGameManager : Singleton<MyGameManager>
    {
        [SerializeField]
        private LevelPreferencesData levelPreferencesData;

        [SerializeField] 
        private ItemPrefabDictionary itemPrefabDictionary;

        private List<String> randomItemsToTest;

        private void Start()
        {
            StartLevel();
        }

        private void StartLevel()
        {
            itemPrefabDictionary.LoadPrefabs(2);
            LoadPrefabs();
            // Shuffle the list of available prefab names
            List<string> availablePrefabNames = new List<string>(itemPrefabDictionary.Prefabs.Keys);
            ShuffleList(availablePrefabNames);

            // Take a subset of prefab names based on CountOfWordsToTest
            randomItemsToTest = availablePrefabNames.Take(2).ToList();
        }

        public void LoadPrefabs()
        {
            // Instantiate all prefabs in the dictionary
            foreach (GameObject prefab in itemPrefabDictionary.Prefabs.Values)
            {
                Vector3 startPosition = prefab.GetComponent<ItemBehaviour>().StartPosition;
                Instantiate(prefab, startPosition, Quaternion.identity);
            }
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
        
        // Fisher-Yates shuffle algorithm
        private void ShuffleList<T>(List<T> list)
        {
            System.Random random = new System.Random();
            int n = list.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
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