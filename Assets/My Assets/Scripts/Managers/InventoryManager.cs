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

        public Transform ItemContent;
        public GameObject InventoryItem;

        private void OnDestroy()
        {
            inventory.Contents.Clear();
        }

        public void AddItemToInventory(MultiLingualData item)
        {
            Debug.Log(item.name);
            if (!inventory.Contents.ContainsKey(item.name))
            {
                inventory.Contents.Add(item.name, item);
            }
        }

        public void RemoveItemFromInventory(MultiLingualData item)
        {
            Debug.Log("HERW");
            Debug.Log(item.name);
            if (inventory.Contents.ContainsKey(item.name))
            {
                inventory.Contents.Remove(item.name);
            }
            
            MyGameManager.Instance.LoadPrefab(item.name);
        }

        public void ListItems()
        {
            foreach (Transform item in ItemContent)
            {
                Destroy(item.gameObject);
            }
            foreach (KeyValuePair<string, MultiLingualData> item in inventory.Contents)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                obj.GetComponent<InventoryItemController>().MultiLingualData = item.Value;
            }
        }
    }
}

