using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using GD;
using My_Assets.Scripts;
using My_Assets.Scripts.Managers;
using My_Assets.Scripts.ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

namespace Third_Party_Assets.Scripts
{
    public class InspectItemManager : MonoBehaviour
    {
        [SerializeField] private InspectItemData inspectItemData;

        [SerializeField]
        [Tooltip("The GameObject offset used during examination.")]
        private GameObject offset;

        [SerializeField]
        [Tooltip("The Canvas used for examination UI.")]
        private Canvas interactingCanvas;

        [SerializeField]
        [Tooltip("The Canvas used for examination UI (alternative reference).")]
        private Canvas examineCanvas;

        [SerializeField]
        private MultiLanguageGameEvent addToInventoryGameEvent;
            
        private ItemBehaviour currentInspectItemBehaviour;

        private void Start()
        {
            inspectItemData.IsExamining = false;
        }

        public void CheckExamining(GameObject hitGameObject)
        {
            currentInspectItemBehaviour = hitGameObject.GetComponent<ItemBehaviour>();
            inspectItemData.ToggleExamination();

            // Store the currently examined object and its original position and rotation
            if (inspectItemData.IsExamining)
            {
                inspectItemData.ExaminedObject = hitGameObject.transform;
                inspectItemData.OriginalPositions[inspectItemData.ExaminedObject] = inspectItemData.ExaminedObject.position;
                inspectItemData.OriginalRotations[inspectItemData.ExaminedObject] = inspectItemData.ExaminedObject.rotation;
            }
        }
        
        void Update()
        {
            //It then checks if the player is close to an interactable object using the CheckUserClose() method.
            //If the player is close, it calls either Examine() or NonExamine() and enables or disables the canvas component accordingly.
                if (inspectItemData.IsExamining)
                {
                    interactingCanvas.enabled = false;
                    Examine(); 
                    //StartExamination();
                    examineCanvas.enabled = true;
                }
                else
                {
                    interactingCanvas.enabled = true;
                    NonExamine(); 
                    //StopExamination();
                    examineCanvas.enabled = false;
                }
        }
        
        
        void Examine()
        {
            if (inspectItemData.ExaminedObject != null)
            {
                CheckPlayerInput();
                inspectItemData.ExaminedObject.position = Vector3.Lerp(inspectItemData.ExaminedObject.position, offset.transform.position, 0.2f);
                Vector3 deltaMouse = Input.mousePosition - inspectItemData.LastMousePosition;
                float rotationSpeed = 1.0f;
                inspectItemData.ExaminedObject.Rotate(deltaMouse.x * rotationSpeed * Vector3.up, Space.World);
                inspectItemData.ExaminedObject.Rotate(deltaMouse.y * rotationSpeed * Vector3.left, Space.World);
                inspectItemData.LastMousePosition = Input.mousePosition;
            }
        }

        //This method is called when the player is not examining an object.
        //It resets the position and rotation of the examined object to its original values stored in the dictionaries.

        void NonExamine()
        {
            if (inspectItemData.ExaminedObject != null)
            {
                // Reset the position and rotation of the examined object to its original values
                if (inspectItemData.OriginalPositions.TryGetValue(inspectItemData.ExaminedObject, out var position))
                {
                    inspectItemData.ExaminedObject.position = Vector3.Lerp(inspectItemData.ExaminedObject.position, position, 0.2f);
                }
                if (inspectItemData.OriginalRotations.TryGetValue(inspectItemData.ExaminedObject, out var rotation))
                {
                    inspectItemData.ExaminedObject.rotation = Quaternion.Slerp(inspectItemData.ExaminedObject.rotation, rotation, 0.2f);
                }
            }
        }
        

        // This method is called when the player starts examining an object. It locks the cursor,
           // makes it visible, and disables the PlayerInput component to prevent player movement during examination.

        void StartExamination()
        {
            inspectItemData.LastMousePosition = Input.mousePosition;

            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }

        private void CheckPlayerInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                currentInspectItemBehaviour.PlaySound(RecordedSoundType.ENGLISH);
            }
            
            else if (Input.GetKeyDown(KeyCode.S))
            {
                currentInspectItemBehaviour.PlaySound(RecordedSoundType.FOREIGN_LANGUAGE);
            }
            
            else if (Input.GetKeyDown(KeyCode.V))
            {
                currentInspectItemBehaviour.DeleteItem();
                addToInventoryGameEvent.Raise(currentInspectItemBehaviour.MultiLingualData);
            }
        }

        //This method is called when the player stops examining an object. It locks the cursor again,
        //hides it, and re-enables the PlayerInput component to allow player movement.

        void StopExamination()
        {
          //Cursor.lockState = CursorLockMode.Locked;
           //Cursor.visible = false;
        }
    }
}