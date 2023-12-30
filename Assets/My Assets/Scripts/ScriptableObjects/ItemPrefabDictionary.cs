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

            // Shuffle the list using Fisher-Yates algorithm  ref https://www.geeksforgeeks.org/shuffle-a-given-array-using-fisher-yates-shuffle-algorithm/
            System.Random random = new System.Random();
            int n = prefabList.Count;
            for (int i = n - 1; i > 0; i--)
            {
                int j = random.Next(0, i + 1);
                (prefabList[i], prefabList[j]) = (prefabList[j], prefabList[i]);
            }

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