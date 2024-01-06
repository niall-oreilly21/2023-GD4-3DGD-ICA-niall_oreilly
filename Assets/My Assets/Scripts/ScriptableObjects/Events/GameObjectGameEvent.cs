using GD;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    /// <summary>
    /// Scriptable Object representing a Game Object game event, inherited from BaseGameEvent<GameObject>.
    /// </summary>
    [CreateAssetMenu(fileName = "GameObjectGameEvent", menuName = "DkIT/Scriptable Objects/Patterns/Events/GameObject")]
    public class GameObjectGameEvent :  BaseGameEvent<GameObject> 
    {
    }
}