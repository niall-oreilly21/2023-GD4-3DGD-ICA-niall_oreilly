using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Inventory", menuName = "DkIT/Scriptable Objects/Game/Inventory")]
        public class Inventory : SerializedScriptableObject
        {
            public Dictionary<string, MultiLingualData> Contents;
            
            public int GetCountOfCorrectWordsOnShoppingList()
            {
                return Contents.Values.Count(item => item.WordIsToBeTested);
            }
        }
}