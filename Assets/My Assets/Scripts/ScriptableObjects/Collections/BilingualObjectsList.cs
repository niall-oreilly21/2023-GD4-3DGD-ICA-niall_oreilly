using GD.Collections;
using My_Assets.Scripts.ScriptableObjects.Languages;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects.Collections
{
    /// <summary>
    /// Scriptable Object representing a MultiLingualData List.
    /// </summary>
    [CreateAssetMenu(fileName = "RuntimeUIPromptList", menuName = "DkIT/Scriptable Objects/Types/Collections/List/BilingualObject", order = 9)]
    public class BilingualObjectList : RuntimeList<MultiLingualData>
    {
    }
}