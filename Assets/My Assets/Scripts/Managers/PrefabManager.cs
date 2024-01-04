using System.Collections.Generic;
using GD;
using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace My_Assets.Scripts.Managers
{
    public class PrefabManager : Singleton<PrefabManager>
    {
        [SerializeField]
        private LevelPreferencesData levelPreferencesData;

        [SerializeField] 
        private ItemPrefabDictionary itemPrefabDictionary;

        private void Start()
        {
            levelPreferencesData.CountOfWordsToLearn = 0;
            levelPreferencesData.CountOfWordsToTest = 2;
            levelPreferencesData.Language = LanguageType.Spanish;
        }

        public void LoadPrefabs(List<MultiLingualData> multiLingualDataList)
        {
            itemPrefabDictionary.LoadPrefabs(levelPreferencesData.CountOfWordsToLearn);
            
            // Instantiate all prefabs in the dictionary
            foreach (GameObject prefab in itemPrefabDictionary.Prefabs.Values)
            {
                ItemBehaviour itemBehaviour = prefab.GetComponent<ItemBehaviour>();
                
                itemBehaviour.MultiLingualData.SetCurrentLanguageToLearnData(levelPreferencesData.Language);
                multiLingualDataList.Add(itemBehaviour.MultiLingualData);
                Instantiate(prefab, itemBehaviour.StartPosition, Quaternion.identity);
            }
        }
        
        public void LoadPrefab(string itemToAdd)
        {
            if (itemPrefabDictionary.Prefabs.TryGetValue(itemToAdd, out GameObject prefab))
            {
                Vector3 startPosition = prefab.GetComponent<ItemBehaviour>().StartPosition;
                Instantiate(prefab, startPosition, Quaternion.identity);
            }
        }
    }
}