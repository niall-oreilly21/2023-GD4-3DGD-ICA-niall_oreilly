using My_Assets.Scripts.ScriptableObjects;
using UnityEngine;

namespace My_Assets.Scripts.Managers
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField]
        private Inventory inventory;

        public void HandleConsumablePickup(MultiLingualData item)
        {
            if (inventory.Contents.ContainsKey(item))
            {
                int count = inventory.Contents[item];
                count++; //since int is value type this is a copy so we need to rewrite in
                inventory.Contents[item] = count;
                // inventory.Contents.Add(item, count);
            }
            else
            {
                inventory.Contents.Add(item, 1);
            }
        }
    }
}

