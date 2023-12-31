using System.Collections.Generic;
using GD;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ItemPrefabDictionary", menuName = "DkIT/Scriptable Objects/Assets/Prefabs/ItemPrefabDictionary", order = 2)]
    public class ItemPrefabDictionary : PrefabDictionary
    {
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
                    Prefabs.TryAdd(prefab.name, prefab);
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