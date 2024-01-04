using System;
using GD;
using My_Assets.Scripts.ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace My_Assets.Scripts
{
    
    public class ItemBehaviour : MonoBehaviour
    {
        [SerializeField]
        private MultiLingualData multiLingualData;

        public MultiLingualData MultiLingualData => multiLingualData;

        public void DeleteItem()
        {
            Destroy(gameObject);
        }
    }
}