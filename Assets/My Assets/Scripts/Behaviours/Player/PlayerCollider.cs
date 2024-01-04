using System;
using GD;
using My_Assets.Scripts.ScriptableObjects.Events;
using Sirenix.OdinInspector;
using UnityEditor.UIElements;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours
{
    public class PlayerCollider : MonoBehaviour
    {
        [SerializeField]
        private string tagToCompare;
        
        [SerializeField]
        private BoolVariable isCollidingWithCurrentObject;
        
        [SerializeField]
        private BoolGameEvent buttonEnabled;
        
        private GameObject currentCollidingObject;
        private bool isColliding;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(tagToCompare))
            {
                isColliding = true;
                currentCollidingObject = other.gameObject;
            }
            else if (other.CompareTag("CheckOut"))
            {
                buttonEnabled.Raise(true);
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(tagToCompare))
            {
                isColliding = false;
                currentCollidingObject = null;
            }
            else if (other.CompareTag("CheckOut"))
            {
                buttonEnabled.Raise(false);
            }
        }
        
        // Check if colliding with a specific GameObject
        public void IsCollidingWith(GameObject otherGameObject)
        {
            if (isColliding && otherGameObject != null && otherGameObject == currentCollidingObject)
            {
                isCollidingWithCurrentObject.Value = true;
            }
        }
    }
}