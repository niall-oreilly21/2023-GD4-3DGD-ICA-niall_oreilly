using GD;
using My_Assets.Scripts.ScriptableObjects.Events;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.Player
{
    /// <summary>
    /// Unity MonoBehaviour for detecting collisions with specific GameObjects and triggering events accordingly.
    /// </summary>
    public class PlayerCollider : MonoBehaviour
    {
        #region Fields
        
        [SerializeField]
        [Tooltip("The tag to compare when detecting collisions.")]
        private string tagToCompare;
    
        [SerializeField]
        [Tooltip("Variable to store whether the player is colliding with the current object.")]
        private BoolVariable isCollidingWithCurrentObject;
    
        [SerializeField]
        [Tooltip("Game event to toggle the state of a button based on collisions.")]
        private BoolGameEvent buttonEnabled;
    
        private GameObject currentCollidingObject;
        private bool isColliding;

        #endregion
        
        /// <summary>
        /// Called when another collider enters the trigger zone.
        /// </summary>
        /// <param name="other">The collider entering the trigger zone.</param>

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
        
        /// <summary>
        /// Called when another collider exits the trigger zone.
        /// </summary>
        /// <param name="other">The collider exiting the trigger zone.</param>

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
        
        /// <summary>
        /// Checks if colliding with a specific GameObject.
        /// </summary>
        /// <param name="otherGameObject">The GameObject to check for collision.</param>
        public void IsCollidingWith(GameObject otherGameObject)
        {
            if (isColliding && otherGameObject != null && otherGameObject == currentCollidingObject)
            {
                isCollidingWithCurrentObject.Value = true;
            }
        }
    }
}