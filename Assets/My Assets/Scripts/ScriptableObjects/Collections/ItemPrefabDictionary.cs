using System.Collections.Generic;
using GD;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects.Collections
{
    /// <summary>
    /// Scriptable object representing a dictionary of item prefabs in the game.
    /// Inherits from PrefabDictionary.
    /// </summary>
    [CreateAssetMenu(fileName = "ItemPrefabDictionary", menuName = "DkIT/Scriptable Objects/Assets/Prefabs/ItemPrefabDictionary", order = 2)]
    public class ItemPrefabDictionary : PrefabDictionary
    {
        /// <summary>
        /// Loads prefabs from the specified folder path, shuffles them, and adds a specified number of items to the dictionary.
        /// </summary>
        /// <param name="countItemsToAdd">The number of items to add to the dictionary.</param>
        public void LoadPrefabs(int countItemsToAdd)
        {
            CheckErrors();
            List<GameObject> prefabList = AssetLoader.FindPrefabs("Assets/" + FolderPath, "t:Prefab");

            FisherYatesAlgorithm.ShuffleList(prefabList);

            // Add only the desired number of items
            int itemsAdded = 0;
            foreach (GameObject prefab in prefabList)
            {
                if (itemsAdded < countItemsToAdd)
                {
                    Prefabs.TryAdd(prefab.name.Replace("WithBehaviour", ""), prefab);
                    itemsAdded++;
                }
                else
                {
                    break; // Stop adding once countItemsToAdd items have been added
                }
            }
        }
    }

}