using System;
using GD;
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
        
        private GameObject currentCollidingObject;
        private bool isColliding;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(tagToCompare))
            {
                isColliding = true;
                currentCollidingObject = other.gameObject;
            }
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag(tagToCompare))
            {
                isColliding = false;
                currentCollidingObject = null;
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