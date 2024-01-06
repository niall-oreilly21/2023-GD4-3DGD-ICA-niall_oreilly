using System.Collections.Generic;
using GD;
using My_Assets.Scripts.Behaviours.Item;
using My_Assets.Scripts.ScriptableObjects;
using My_Assets.Scripts.ScriptableObjects.Collections;
using My_Assets.Scripts.ScriptableObjects.Languages;
using UnityEngine;

namespace My_Assets.Scripts.Managers
{
    /// <summary>
    /// Manages the loading and instantiation of prefabs based on the level preferences.
    /// </summary>
    public class PrefabManager : Singleton<PrefabManager>
    {
        #region Fields

        [SerializeField]
        [Tooltip("The level preferences data containing information about the level.")]
        private LevelPreferencesData levelPreferencesData;

        [SerializeField]
        [Tooltip("Dictionary containing prefabs for each item.")]
        private ItemPrefabDictionary itemPrefabDictionary;

        #endregion
        
        /// <summary>
        /// Loads prefabs from the dictionary based on the level preferences and instantiates them in the scene.
        /// </summary>
        /// <param name="multiLingualDataList">List to store MultiLingualData objects associated with loaded prefabs.</param>
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
        
        /// <summary>
        /// Loads a specific prefab based on the item to add and instantiates it in the scene.
        /// </summary>
        /// <param name="itemToAdd">The name of the item to load and instantiate.</param>
        public void LoadPrefab(string itemToAdd)
        {
            if (itemPrefabDictionary.Prefabs.TryGetValue(itemToAdd, out GameObject prefab))
            {
                Instantiate(prefab);
            }
        }
    }
}