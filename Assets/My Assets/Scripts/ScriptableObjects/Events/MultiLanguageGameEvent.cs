using GD;
using My_Assets.Scripts.ScriptableObjects;
using My_Assets.Scripts.ScriptableObjects.Languages;
using UnityEngine;

namespace My_Assets.Scripts
{
    /// <summary>
    /// Scriptable Object representing a MultiLingualData game event, inherited from BaseGameEvent<MultiLingualData>.
    /// </summary>
    [CreateAssetMenu(fileName = "ItemDataGameEvent",
        menuName = "DkIT/Scriptable Objects/Events/MultiLingualObject")]
    public class MultiLanguageGameEvent :BaseGameEvent<MultiLingualData>
    {
    
    }
}