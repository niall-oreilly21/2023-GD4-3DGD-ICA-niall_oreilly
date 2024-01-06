using System.Collections.Generic;
using System.Linq;
using My_Assets.Scripts.ScriptableObjects.Languages;
using Sirenix.OdinInspector;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects.Inventory
{
    /// <summary>
    /// Scriptable object representing the player's inventory in the game.
    /// </summary>
    [CreateAssetMenu(fileName = "Inventory", menuName = "DkIT/Scriptable Objects/Game/Inventory")]
        public class Inventory : SerializedScriptableObject
        {
            #region Fields
            
            [Tooltip("Dictionary storing items in the inventory along with their multi-lingual data.")]
            public Dictionary<string, MultiLingualData> Contents;
            
            #endregion


            /// <summary>
            /// Returns the count of items in the inventory marked for testing (WordIsToBeTested).
            /// </summary>
            /// <returns>The count of items to be tested in the inventory.</returns>
            public int GetCountOfCorrectWordsOnShoppingList()
            {
                return Contents.Values.Count(item => item.WordIsToBeTested);
            }
        }
}