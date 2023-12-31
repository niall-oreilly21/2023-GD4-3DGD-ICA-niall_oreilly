using System;
using System.Collections.Generic;
using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace My_Assets.Scripts.Managers
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        private Inventory inventory;

        [SerializeField] 
        private LevelPreferencesData levelPreferencesData;

        private bool isInventoryFull;

        private void Start()
        {
            isInventoryFull = false;
            inventory.Contents.Clear();
        }
        
        public void AddItemToInventory(MultiLingualData item)
        {
            if (!isInventoryFull)
            {
                inventory.Contents.TryAdd(item.name, item);
            }
        }
        public void RemoveItemFromInventory(MultiLingualData item)
        {
            if (inventory.Contents.ContainsKey(item.name))
            {
                inventory.Contents.Remove(item.name);
            }
            MyGameManager.Instance.LoadPrefab(item.name);
        }

        private void Update()
        {
            isInventoryFull = inventory.Contents.Count == levelPreferencesData.CountOfWordsToTest;
            MyUIManager.Instance.DisplayInventoryFull(isInventoryFull);
        }
        
    }
}

