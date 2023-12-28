using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Inventory",
            menuName = "DkIT/Scriptable Objects/Game/Inventory")]
        public class Inventory : SerializedScriptableObject
        {
            public Dictionary<MultiLingualData, int> Contents;
        }
}