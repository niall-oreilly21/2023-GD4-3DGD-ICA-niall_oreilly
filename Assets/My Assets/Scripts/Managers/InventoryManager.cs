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

        private void OnDestroy()
        {
            inventory.Contents.Clear();
        }
        public void AddItemToInventory(MultiLingualData item)
        {
            if (!inventory.Contents.ContainsKey(item.name))
            {
                inventory.Contents.Add(item.name, item);
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
    }
}

