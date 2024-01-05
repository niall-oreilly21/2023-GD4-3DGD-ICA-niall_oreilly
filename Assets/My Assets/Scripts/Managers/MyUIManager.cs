using System.Collections.Generic;
using System.Linq;
using GD;
using My_Assets.Scripts.Behaviours.UI;
using My_Assets.Scripts.Enums;
using My_Assets.Scripts.ScriptableObjects;
using TMPro;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace My_Assets.Scripts.Managers
{
    public class MyUIManager : Singleton<MyUIManager>
    {
        [SerializeField]
        private UIComponent shoppingListUIComponent;
        
        [SerializeField]
        private UIComponent inventoryUIComponent;

        [SerializeField]
        private MultiUIComponent endMenuInventoryUIComponent;

        [SerializeField] 
        private Inventory inventory;
        
        [SerializeField] 
        private GameObject inventoryIsFull;

        [SerializeField] 
        private GameObject tutorialText;

        [SerializeField] 
        private TextMeshProUGUI promptText;

        [SerializeField] 
        private LanguageDictionary languageDictionary;

        [SerializeField] 
        private Sprite tickIcon;
        
        [SerializeField] 
        private Sprite xIcon;

        [SerializeField] 
        private GameObject gameCanvas;
        
        [SerializeField] 
        private GameObject endMenuCanvas;

        [SerializeField] 
        private TextMeshProUGUI endScoreText;

        private string currentLanguageToLearn;
        
        public void DisplayShoppingList(List<string> itemsInShoppingList)
        {
            itemsInShoppingList.Sort();
            
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
                var newItem = Instantiate(inventoryUIComponent.UiItem, inventoryUIComponent.ItemContent);
                newItem.GetComponent<InventoryItemController>().MultiLingualData = item;
                newItem.transform.Find("Image").GetComponent<Image>().sprite = item.Icon;
            }
        }

        public void DisplayEndMenu(List<MultiLingualData> itemsNotInInventory, int totalWordsToLearn)
        {
            int endScore = DisplayInventoryEndCart();
            DisplayItemsNotInInventory(itemsNotInInventory);
            UpdateScoreText(endScore, totalWordsToLearn);
            UnHideEndScreen();
        }

        private void UpdateScoreText(int endScore, int totalWordsToLearn)
        {
            endScoreText.SetText("Score " + "\n" + endScore + " / " + totalWordsToLearn);
        }
        private int DisplayInventoryEndCart()
        {
            var sortedItems = inventory.Contents.Values.OrderBy(item => item.EnglishLanguageData.LanguageText);
            int endScore = 0;
            
            foreach (MultiLingualData item in sortedItems)
            {
                var newItem = DisplayEndMenuCartItem(item.EnglishLanguageData.LanguageText, item.CurrentLanguageToLearnData.LanguageText, endMenuInventoryUIComponent.ItemContent);
                newItem.transform.Find("Icon").GetComponent<Image>().sprite = item.WordIsToBeTested ? tickIcon : xIcon;

                if (item.WordIsToBeTested)
                {
                    endScore++;
                }
            }

            return endScore;
        }

        private void DisplayItemsNotInInventory(List<MultiLingualData> itemsNotInInventory)
        {
            var sortedItems = itemsNotInInventory.OrderBy(item => item.EnglishLanguageData.LanguageText);
            
            foreach (MultiLingualData item in sortedItems)
            {
                var newItem = DisplayEndMenuCartItem(item.EnglishLanguageData.LanguageText, item.CurrentLanguageToLearnData.LanguageText, endMenuInventoryUIComponent.ItemContentTwo);
                newItem.transform.Find("Icon").GetComponent<Image>().sprite = item.Icon;
            }
        }
        
        private void UnHideEndScreen()
        {
            gameCanvas.SetActive(false);
            endMenuCanvas.SetActive(true);
        }

        public void SetTutorialTextState(bool isActive)
        {
            tutorialText.SetActive(isActive);
        }

        public void SetCurrentLanguage(LanguageType languageTypeToLearn)
        {
            currentLanguageToLearn = languageDictionary.GetCurrentLanguageLabel(languageTypeToLearn);
        }
        
        public void SetPromptText()
        {
            promptText.SetText("To Play " + currentLanguageToLearn);
        }
        
        private GameObject DisplayEndMenuCartItem(string englishText, string foreignText, Transform itemContent)
        {
            var newItem = Instantiate(endMenuInventoryUIComponent.UiItem, itemContent);
            
            newItem.transform.Find("ForeignText").GetComponent<TextMeshProUGUI>().SetText(foreignText);
            newItem.transform.Find("EnglishText").GetComponent<TextMeshProUGUI>().SetText(englishText);

            return newItem;
        }
        
        public void DisplayInventoryFull(bool isActive)
        {
            inventoryIsFull.SetActive(isActive);
        }
    }
}