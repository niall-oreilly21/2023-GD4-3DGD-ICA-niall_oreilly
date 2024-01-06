using My_Assets.Scripts.ScriptableObjects;
using My_Assets.Scripts.ScriptableObjects.Languages;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.UI
{
    /// <summary>
    /// Unity MonoBehaviour for managing inventory items.
    /// </summary>
    public class InventoryItemController : MonoBehaviour
    {
        #region Fields
        
        [SerializeField]
        [Tooltip("Event triggered when removing this item from the inventory.")]
        private MultiLanguageGameEvent removeItemFromInventory;
        
        private MultiLingualData multiLingualData;
        #endregion

        #region Properties
        public MultiLingualData MultiLingualData
        {
            set => multiLingualData = value;
        }
        #endregion


        /// <summary>
        /// Removes the item from the inventory, triggers related events, and destroys the game object.
        /// </summary>
        public void RemoveItem()
        {
            removeItemFromInventory.Raise(multiLingualData);
            Destroy(gameObject);
        }
    }
}
