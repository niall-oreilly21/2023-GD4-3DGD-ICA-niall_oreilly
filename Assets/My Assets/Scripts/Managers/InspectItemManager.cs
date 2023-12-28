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
        
        //The last recorded mouse position during examination.
        private Vector3 lastMousePosition;

        //The currently examined object during examination.
        private Transform examinedObject;

        //Original positions of interactable objects
        private Dictionary<Transform, Vector3> originalPositions = new Dictionary<Transform, Vector3>();

        //Original rotations of interactable objects
        private Dictionary<Transform, Quaternion> originalRotations = new Dictionary<Transform, Quaternion>();

        void Start()
        {
            //_canva.enabled = false;
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
                        inspectItemData.ToggleExamination();

                        // Store the currently examined object and its original position and rotation
                        if (inspectItemData.IsExamining)
                        {
                        
                            examinedObject = hit.transform;
                            originalPositions[examinedObject] = examinedObject.position;
                            originalRotations[examinedObject] = examinedObject.rotation;
                        }
                    }
                }
            }

            //It then checks if the player is close to an interactable object using the CheckUserClose() method.
            //If the player is close, it calls either Examine() or NonExamine() and enables or disables the canvas component accordingly.
            
                if (inspectItemData.IsExamining)
                {
                    inspectItemData.InteractingCanvas.enabled = false;
                    Examine(); 
                    StartExamination();
                    inspectItemData.ExamineCanvas.enabled = true;
                }
                else
                {
                    inspectItemData.InteractingCanvas.enabled = true;
                    NonExamine(); StopExamination();
                    inspectItemData.ExamineCanvas.enabled = false;
                }
            //}
            //else _canva.enabled = false;

        }

        // This method is called when the player starts examining an object. It locks the cursor,
           // makes it visible, and disables the PlayerInput component to prevent player movement during examination.

        void StartExamination()
        {
            lastMousePosition = Input.mousePosition;

            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;
        }

        private void CheckPlayerInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                inspectItemData.ItemLanguageToPlay?.Raise(RecordedSoundType.ENGLISH);
            }
            
            else if (Input.GetKeyDown(KeyCode.S))
            {
                inspectItemData.ItemLanguageToPlay?.Raise(RecordedSoundType.FOREIGN_LANGUAGE);
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
            if (examinedObject != null)
            {
                CheckPlayerInput();
                examinedObject.position = Vector3.Lerp(examinedObject.position, inspectItemData.Offset.transform.position, 0.2f);
                Vector3 deltaMouse = Input.mousePosition - lastMousePosition;
                float rotationSpeed = 1.0f;
                examinedObject.Rotate(deltaMouse.x * rotationSpeed * Vector3.up, Space.World);
                examinedObject.Rotate(deltaMouse.y * rotationSpeed * Vector3.left, Space.World);
                lastMousePosition = Input.mousePosition;
            }
        }

        //This method is called when the player is not examining an object.
        //It resets the position and rotation of the examined object to its original values stored in the dictionaries.

        void NonExamine()
        {
            if (examinedObject != null)
            {
                // Reset the position and rotation of the examined object to its original values
                if (originalPositions.ContainsKey(examinedObject))
                {
                    examinedObject.position = Vector3.Lerp(examinedObject.position, originalPositions[examinedObject], 0.2f);
                }
                if (originalRotations.ContainsKey(examinedObject))
                {
                    examinedObject.rotation = Quaternion.Slerp(examinedObject.rotation, originalRotations[examinedObject], 0.2f);
                }
            }
        }
        // This method calculates the distance between the player(targetObject) and 
       // an object called tableObject.If the distance is less than 2 units, it returns true, indicating that the player is close to the object.
    }
}