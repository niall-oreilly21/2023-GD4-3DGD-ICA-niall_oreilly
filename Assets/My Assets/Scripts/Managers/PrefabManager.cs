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
            levelPreferencesData.CountOfWordsToLearn = 15;
            levelPreferencesData.CountOfWordsToTest = 15;
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
                Instantiate(prefab);
            }
        }
        
        public void LoadPrefab(string itemToAdd)
        {
            if (itemPrefabDictionary.Prefabs.TryGetValue(itemToAdd, out GameObject prefab))
            {
                Instantiate(prefab);
            }
        }
    }
}