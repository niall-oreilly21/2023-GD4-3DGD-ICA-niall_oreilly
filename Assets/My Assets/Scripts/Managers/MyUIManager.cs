using System;
using System.Collections.Generic;
using GD;
using GD.Examples;
using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.Serialization;

namespace My_Assets.Scripts.Managers
{
    public class MyUIManager : Singleton<MyUIManager>
    {
        [SerializeField]
        private UIComponent shoppingListUIComponent;
        
        [SerializeField]
        private UIComponent inventoryUIComponent;

        [SerializeField] 
        private Inventory inventory;
        
        public void DisplayShoppingList(List<string> itemsInShoppingList)
        {
            foreach (string item in itemsInShoppingList)
            {
                GameObject obj = Instantiate(shoppingListUIComponent.UiItem, shoppingListUIComponent.ItemContent);
                shoppingListUIComponent.SetUpTextReference(obj, item);
            }
        }
        
        public void DisplayInventory()
        {
            foreach (Transform item in inventoryUIComponent.ItemContent)
            {
                Destroy(item.gameObject);
            }
            foreach (KeyValuePair<string, MultiLingualData> item in inventory.Contents)
            {
                GameObject obj = Instantiate(inventoryUIComponent.UiItem, inventoryUIComponent.ItemContent);
                obj.GetComponent<InventoryItemController>().MultiLingualData = item.Value;
            }
        }
    }
}