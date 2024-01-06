using GD;
using GD.Selection;
using My_Assets.Scripts.Behaviours.Item;
using My_Assets.Scripts.ScriptableObjects.Events;
using My_Assets.Scripts.ScriptableObjects.Inspect;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects.Responses
{
    /// <summary>
    /// Scriptable Object representing a selection response for examining an item.
    /// Implements the ISelectionResponse interface.
    /// </summary>
    [CreateAssetMenu(fileName = "ExamineItemSelectionResponse", menuName = "DkIT/Scriptable Objects/Other/Responses/ExamineItem")]
    public class ExamineItemSelectionResponse : ScriptableObject, ISelectionResponse
    {
        #region Fields

        [SerializeField]
        [Tooltip("Event triggered when an object is examined.")]
        private GameObjectGameEvent examineObjectGameEvent;

        [SerializeField]
        [Tooltip("Event triggered to check if the player is in range of the examined object.")]
        private GameObjectGameEvent checkInRange;

        [SerializeField]
        [Tooltip("Variable indicating whether the player is currently colliding with the examined object.")]
        private BoolVariable isCollidingWithCurrentObject;

        [SerializeField]
        [Tooltip("Event triggered to toggle the prompt text based on the examining status.")]
        private BoolGameEvent togglePromptTextGameEvent;

        [SerializeField]
        [Tooltip("Data container for inspecting item-related information.")]
        private InspectItemData inspectItemData;

        #endregion
        
        
        /// <summary>
        /// Called when an object is deselected. Updates state based on examining status.
        /// </summary>
        public void OnDeselect(Transform selection)
        {
            if (!inspectItemData.IsExamining)
            {
                isCollidingWithCurrentObject.Value = false;
                togglePromptTextGameEvent.Raise(false);
            }
        }
        
        /// <summary>
        /// Called when an object is selected. Initiates checks and raises events based on conditions.
        /// </summary>
        public void OnSelect(Transform selection)
        {
            checkInRange.Raise(selection.gameObject);

            if (isCollidingWithCurrentObject.Value)
            {
                if (!inspectItemData.IsExamining)
                {
                    togglePromptTextGameEvent.Raise(true);
                }
                
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (inspectItemData.IsExamining)
                    {
                        selection.gameObject.GetComponent<ItemBehaviour>().StartScaleTween();
                    }
                    examineObjectGameEvent.Raise(selection.gameObject);
                }
            }
        }
    }
}