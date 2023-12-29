using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using GD;
using My_Assets.Scripts;
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

        private void Start()
        {
            inspectItemData.IsExamining = false;
        }

        void Update()
        {
            // it performs a raycast from the camera to the mouse position and checks if it hits an object tagged as "Object."
            // If it does, it toggles the examination state and stores the examined object's original position and rotation.

            if (Input.GetKeyDown(KeyCode.E))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.CompareTag("Pickable"))
                    {
                        inspectItemData.InspectItemBehaviour = hit.transform.gameObject.GetComponent<ItemBehaviour>();
                        inspectItemData.ToggleExamination();

                        // Store the currently examined object and its original position and rotation
                        if (inspectItemData.IsExamining)
                        {
                            inspectItemData.ExaminedObject = hit.transform;
                            inspectItemData.OriginalPositions[inspectItemData.ExaminedObject] = inspectItemData.ExaminedObject.position;
                            inspectItemData.OriginalRotations[inspectItemData.ExaminedObject] = inspectItemData.ExaminedObject.rotation;
                        }
                    }
                }
            }

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
            //}
            //else _canva.enabled = false;

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
                inspectItemData.InspectItemBehaviour.PlaySound(RecordedSoundType.ENGLISH);
            }
            
            else if (Input.GetKeyDown(KeyCode.S))
            {
                inspectItemData.InspectItemBehaviour.PlaySound(RecordedSoundType.FOREIGN_LANGUAGE);
            }
            
            else if (Input.GetKeyDown(KeyCode.V))
            {
                inspectItemData.InspectItemBehaviour.AddToInventory();
            }
        }

        //This method is called when the player stops examining an object. It locks the cursor again,
        //hides it, and re-enables the PlayerInput component to allow player movement.

        void StopExamination()
        {
          //Cursor.lockState = CursorLockMode.Locked;
           //Cursor.visible = false;
        }

       
        // This method is called when the player is examining an object.
        // It moves the examined object towards the offset object and allows the player to rotate it based on mouse movement.

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
                if (inspectItemData.OriginalPositions.ContainsKey(inspectItemData.ExaminedObject))
                {
                    inspectItemData.ExaminedObject.position = Vector3.Lerp(inspectItemData.ExaminedObject.position, inspectItemData.OriginalPositions[inspectItemData.ExaminedObject], 0.2f);
                }
                if (inspectItemData.OriginalRotations.ContainsKey(inspectItemData.ExaminedObject))
                {
                    inspectItemData.ExaminedObject.rotation = Quaternion.Slerp(inspectItemData.ExaminedObject.rotation, inspectItemData.OriginalRotations[inspectItemData.ExaminedObject], 0.2f);
                }
            }
        }
    }
}