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

        public void HandleConsumablePickup(MultiLingualData item)
        {
            if (!inventory.Contents.ContainsKey(item.name))
            {
                inventory.Contents.Add(item.name, item);
            }
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
            }
        }
    }
}

