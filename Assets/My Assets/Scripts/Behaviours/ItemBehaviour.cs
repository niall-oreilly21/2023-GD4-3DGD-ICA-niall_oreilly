using System;
using DG.Tweening;
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
        private float startScale = 1f;
        
        [SerializeField] 
        private float targetScale = 0.5f;
        
        [SerializeField] 
        private float tweenDuration = 1f;
        
        [SerializeField]
        private MultiLingualData multiLingualData;

        public MultiLingualData MultiLingualData => multiLingualData;

        private void Start()
        {
            startScale = transform.localScale.x;
            targetScale = startScale * 2;
            // Call the method to start the tween
            StartScaleTween();
        }

        private void StartScaleTween()
        {
            // Reset the scale to the starting scale (optional)
            transform.localScale = new Vector3(startScale, startScale, startScale);

            // Use DOTween to tween the object's scale
            transform.DOScale(targetScale, tweenDuration)
                .SetEase(Ease.InOutQuad)  // You can change the easing function
                .SetLoops(-1, LoopType.Yoyo); // Infinite loop (grows and shrinks continuously)
        }

        public void DeleteItem()
        {
            Destroy(gameObject);
        }
    }
}