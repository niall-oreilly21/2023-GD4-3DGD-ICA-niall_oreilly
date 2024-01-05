using System;
using GD;
using My_Assets.Scripts.Behaviours;
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

        private void Start()
        {
            // gameObject.AddComponent<GlowEffect>();
            // gameObject.GetComponent<GlowEffect>().StartGlow();
        }

        public void DeleteItem()
        {
            Destroy(gameObject);
        }
    }
}