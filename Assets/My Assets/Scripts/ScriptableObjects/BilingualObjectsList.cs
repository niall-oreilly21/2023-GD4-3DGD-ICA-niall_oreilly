using GD.Collections;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "RuntimeUIPromptList", menuName = "DkIT/Scriptable Objects/Types/Collections/List/BilingualObject", order = 9)]
    public class BilingualObjectList : RuntimeList<MultiLingualObject>
    {
    }
}