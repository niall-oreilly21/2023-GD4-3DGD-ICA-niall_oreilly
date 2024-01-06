using My_Assets.Scripts.ScriptableObjects;
using My_Assets.Scripts.ScriptableObjects.Inventory;
using My_Assets.Scripts.ScriptableObjects.Languages;
using UnityEngine;

namespace My_Assets.Scripts.Managers
{
    /// <summary>
    /// Manages the player's inventory and related functionalities.
    /// </summary>
    public class InventoryManager : MonoBehaviour
    {
        #region Fields
        
        [SerializeField]
        [Tooltip("Reference to the player's inventory.")]
        private Inventory inventory;

        [SerializeField] 
        [Tooltip("Data containing preferences for game levels.")]
        private LevelPreferencesData levelPreferencesData;

        private bool isInventoryFull;
        
        #endregion
        
        private void Start()
        {
            isInventoryFull = false;
            inventory.Contents.Clear();
        }
        
        /// <summary>
        /// Adds an item to the player's inventory.
        /// </summary>
        /// <param name="item">The item to be added.</param>
        public void AddItemToInventory(MultiLingualData item)
        {
            if (!isInventoryFull)
            {
                inventory.Contents.TryAdd(item.name, item);
            }
        }

        /// <summary>
        /// Removes an item from the player's inventory.
        /// </summary>
        /// <param name="item">The item to be removed.</param>
        public void RemoveItemFromInventory(MultiLingualData item)
        {
            if (inventory.Contents.ContainsKey(item.name))
            {
                inventory.Contents.Remove(item.name);
            }
            PrefabManager.Instance.LoadPrefab(item.name);
        }

        private void Update()
        {
            isInventoryFull = inventory.Contents.Count == levelPreferencesData.CountOfWordsToTest;
            MyUIManager.Instance.DisplayInventoryFull(isInventoryFull);
        }
    }
}