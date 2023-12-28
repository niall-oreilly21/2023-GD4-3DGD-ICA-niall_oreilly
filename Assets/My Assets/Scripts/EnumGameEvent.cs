using System;
using GD;
using UnityEngine;

namespace My_Assets.Scripts
{
    [CreateAssetMenu(fileName = "StringGameEvent",
        menuName = "DkIT/Scriptable Objects/Patterns/Events/Enum")]
    public class EnumGameEvent : BaseGameEvent<Enum>
    {
    }
}