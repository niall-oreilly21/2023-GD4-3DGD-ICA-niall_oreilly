using System;
using GD;
using UnityEngine;

namespace My_Assets.Scripts
{
    /// <summary>
    /// Scriptable Object representing a enum game event, inherited from BaseGameEvent<Enum>.
    /// </summary>
    [CreateAssetMenu(fileName = "StringGameEvent",
        menuName = "DkIT/Scriptable Objects/Patterns/Events/Enum")]
    public class EnumGameEvent : BaseGameEvent<Enum>
    {
    }
}