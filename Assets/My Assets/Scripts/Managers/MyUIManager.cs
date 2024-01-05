using System.Collections.Generic;
using System.Linq;
using GD;
using My_Assets.Scripts.Behaviours.UI;
using My_Assets.Scripts.Components;
using My_Assets.Scripts.Enums;
using My_Assets.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Managers
{
    /// <summary>
    /// Manages various UI elements in the game, such as shopping lists, inventory, and end menu.
    /// TODO Create different subclasses to make this class smaller e.g StarterUI
    /// </summary>
    public class MyUIManager : Singleton<MyUIManager>
    {
        #region Fields
        
        [SerializeField]
        [Tooltip("UI component for displaying shopping list items.")]
        private UIComponent shoppingListUIComponent;
        
        [SerializeField]
        [Tooltip("UI component for displaying inventory items.")]
        private UIComponent inventoryUIComponent;

        [SerializeField]
        [Tooltip("UI component for displaying end menu inventory items.")]
        private MultiUIComponent endMenuInventoryUIComponent;

        [SerializeField] 
        [Tooltip("Reference to the player's inventory.")]
        private Inventory inventory;
        
        [SerializeField] 
        [Tooltip("GameObject indicating that the inventory is full.")]
        private GameObject inventoryIsFull;

        [SerializeField] 
        [Tooltip("GameObject containing tutorial text.")]
        private GameObject tutorialText;

        [SerializeField] 
        [Tooltip("TextMeshProUGUI for displaying prompts.")]
        private TextMeshProUGUI promptText;

        [SerializeField] 
        [Tooltip("Dictionary containing language labels.")]
        private LanguageDictionary languageDictionary;

        [SerializeField] 
        [Tooltip("Sprite for the tick icon.")]
        private Sprite tickIcon;
        
        [SerializeField] 
        [Tooltip("Sprite for the x icon.")]
        private Sprite xIcon;

        [SerializeField] 
        [Tooltip("Canvas for the game.")]
        private GameObject gameCanvas;
        
        [SerializeField] 
        [Tooltip("Canvas for the end menu.")]
        private GameObject endMenuCanvas;

        [SerializeField] 
        [Tooltip("TextMeshProUGUI for displaying the end score.")]
        private TextMeshProUGUI endScoreText;

        private string currentLanguageToLearn;
        
        #endregion
        
        /// <summary>
        /// Displays the shopping list UI with sorted items.
        /// </summary>
        /// <param name="itemsInShoppingList">List of items in the shopping list.</param>
        public void DisplayShoppingList(List<string> itemsInShoppingList)
        {
            itemsInShoppingList.Sort();
            
            foreach (string item in itemsInShoppingList)
            {
                GameObject obj = Instantiate(shoppingListUIComponent.UiItem, shoppingListUIComponent.ItemContent);
                shoppingListUIComponent.SetUpTextReference(obj, item);
            }
        }
        
        /// <summary>
        /// Displays the inventory UI with items.
        /// </summary>
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

        /// <summary>
        /// Displays the end menu with inventory items, items not in inventory, and the end score.
        /// </summary>
        /// <param name="itemsNotInInventory">List of items not in the inventory.</param>
        /// <param name="totalWordsToLearn">Total words to learn in the level.</param>
        public void DisplayEndMenu(List<MultiLingualData> itemsNotInInventory, int totalWordsToLearn)
        {
            int endScore = DisplayInventoryEndCart();
            DisplayItemsNotInInventory(itemsNotInInventory);
            UpdateScoreText(endScore, totalWordsToLearn);
            UnHideEndScreen();
        }

        /// <summary>
        /// Updates the score text in the end menu.
        /// </summary>
        /// <param name="endScore">The score achieved.</param>
        /// <param name="totalWordsToLearn">Total words to learn in the level.</param>
        private void UpdateScoreText(int endScore, int totalWordsToLearn)
        {
            endScoreText.SetText("Score " + "\n" + endScore + " / " + totalWordsToLearn);
        }
        
        /// <summary>
        /// Displays the inventory items in the end menu cart and calculates the end score.
        /// </summary>
        /// <returns>The end score achieved.</returns>
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

        /// <summary>
        /// Displays items not in the inventory in the end menu.
        /// </summary>
        /// <param name="itemsNotInInventory">List of items not in the inventory.</param>
        private void DisplayItemsNotInInventory(List<MultiLingualData> itemsNotInInventory)
        {
            var sortedItems = itemsNotInInventory.OrderBy(item => item.EnglishLanguageData.LanguageText);
            
            foreach (MultiLingualData item in sortedItems)
            {
                var newItem = DisplayEndMenuCartItem(item.EnglishLanguageData.LanguageText, item.CurrentLanguageToLearnData.LanguageText, endMenuInventoryUIComponent.ItemContentTwo);
                newItem.transform.Find("Icon").GetComponent<Image>().sprite = item.Icon;
            }
        }
        
        /// <summary>
        /// Unhides the end screen and hides the game canvas.
        /// </summary>
        private void UnHideEndScreen()
        {
            gameCanvas.SetActive(false);
            endMenuCanvas.SetActive(true);
        }

        /// <summary>
        /// Sets the state of the tutorial text.
        /// </summary>
        /// <param name="isActive">Whether the tutorial text should be active.</param>
        public void SetTutorialTextState(bool isActive)
        {
            tutorialText.SetActive(isActive);
        }

        /// <summary>
        /// Sets the current language for learning.
        /// </summary>
        /// <param name="languageTypeToLearn">The language type to learn.</param>

        public void SetCurrentLanguage(LanguageType languageTypeToLearn)
        {
            currentLanguageToLearn = languageDictionary.GetCurrentLanguageLabel(languageTypeToLearn);
        }
        
        /// <summary>
        /// Sets the prompt text based on the current language to learn.
        /// </summary>
        public void SetPromptText()
        {
            promptText.SetText("To Play " + currentLanguageToLearn);
        }
        
        /// <summary>
        /// Displays an item in the end menu cart.
        /// </summary>
        /// <param name="englishText">The English text of the item.</param>
        /// <param name="foreignText">The foreign language text of the item.</param>
        /// <param name="itemContent">The parent content transform.</param>
        /// <returns>The instantiated item GameObject.</returns>
        private GameObject DisplayEndMenuCartItem(string englishText, string foreignText, Transform itemContent)
        {
            var newItem = Instantiate(endMenuInventoryUIComponent.UiItem, itemContent);
            
            newItem.transform.Find("ForeignText").GetComponent<TextMeshProUGUI>().SetText(foreignText);
            newItem.transform.Find("EnglishText").GetComponent<TextMeshProUGUI>().SetText(englishText);

            return newItem;
        }
        
        /// <summary>
        /// Displays the inventory full indicator.
        /// </summary>
        /// <param name="isActive">Whether the inventory full indicator should be active.</param>
        public void DisplayInventoryFull(bool isActive)
        {
            inventoryIsFull.SetActive(isActive);
        }
    }
}