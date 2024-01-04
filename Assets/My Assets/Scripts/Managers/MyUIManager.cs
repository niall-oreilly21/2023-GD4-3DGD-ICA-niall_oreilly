using System;
using System.Collections.Generic;
using GD;
using GD.Examples;
using My_Assets.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

namespace My_Assets.Scripts.Managers
{
    public class MyUIManager : Singleton<MyUIManager>
    {
        [SerializeField]
        private UIComponent shoppingListUIComponent;
        
        [SerializeField]
        private UIComponent inventoryUIComponent;
        
        [SerializeField]
        private UIComponent cartUIComponent;

        [SerializeField] 
        private Inventory inventory;
        
        [SerializeField] 
        private GameObject inventoryIsFull;
        
        [SerializeField] 
        private GameObject shoppingListUI;

        [SerializeField] 
        private GameObject endMenuUI;

        [SerializeField] 
        private GameObject tutorialText;
        
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
            foreach (MultiLingualData item in inventory.Contents.Values)
            {
                GameObject obj = Instantiate(inventoryUIComponent.UiItem, inventoryUIComponent.ItemContent);
                obj.GetComponent<InventoryItemController>().MultiLingualData = item;
            }
        }

        public void DisplayInventoryEndCart(List<MultiLingualData> itemsNotInInventory, int totalWordsInShoppingList)
        {
            foreach (MultiLingualData item in inventory.Contents.Values)
            {
                DisplayEndMenuCartItem(item.EnglishLanguageData.LanguageText, item.CurrentLanguageToLearnData.LanguageText, item.WordIsToBeTested);
            }

        }

        public void SetTutorialTextState(bool isActive)
        {
            tutorialText.SetActive(isActive);
        }

        public void UnHideEndScreen()
        {
            shoppingListUI.SetActive(false);
            endMenuUI.SetActive(true);
        }
        private void DisplayEndMenuCartItem(string englishText, string foreignText, bool isCorrect)
        {
            GameObject obj = Instantiate(cartUIComponent.UiItem, cartUIComponent.ItemContent);

            obj.transform.Find("EnglishText").GetComponent<TextMeshProUGUI>().text = englishText;
            obj.transform.Find("ForeignText").GetComponent<TextMeshProUGUI>().text = foreignText;
           // obj.transform.Find("ItemState").GetComponent<Image>().sprite = null;
        }
        
        public void DisplayInventoryFull(bool isActive)
        {
            inventoryIsFull.SetActive(isActive);
        }
    }
}