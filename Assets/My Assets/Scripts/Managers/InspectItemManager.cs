using GD;
using My_Assets.Scripts.Behaviours.Item;
using My_Assets.Scripts.ScriptableObjects;
using My_Assets.Scripts.ScriptableObjects.Events;
using UnityEngine;

namespace My_Assets.Scripts.Managers
{
    /// <summary>
    /// Manager for inspecting and interacting with items in the game.
    /// Video ref: https://www.youtube.com/watch?v=Ya0VkoAjDmY&t=257s&ab_channel=LearnWithYas
    /// </summary>
    public class InspectItemManager : MonoBehaviour
    {
        #region Fields

        [SerializeField] private InspectItemData inspectItemData;

        [SerializeField]
        [Tooltip("The GameObject offset used during examination.")]
        private GameObject offset;

        [SerializeField]
        [Tooltip("The Canvas used for examination UI (alternative reference).")]
        private GameObject examineCanvas;

        [SerializeField]
        [Tooltip("Reference to the GameObject representing English text.")]
        private GameObject englishText;

        [SerializeField]
        [Tooltip("Data containing preferences for game levels.")]
        private LevelPreferencesData levelPreferencesData;

        [SerializeField]
        [Tooltip("Game event triggered when an item is added to the inventory.")]
        private MultiLanguageGameEvent addToInventoryGameEvent;

        [SerializeField]
        [Tooltip("Game event triggered to toggle prompt text.")]
        private BoolGameEvent togglePromptTextGameEvent;

        private ItemBehaviour currentInspectItemBehaviour;

        [SerializeField]
        [Tooltip("Game event triggered to set tutorial text.")]
        private StringGameEvent setTutorialTextGameEvent;

        #endregion

        #region Methods

        private void Start()
        {
            inspectItemData.IsExamining = false;
        }

        /// <summary>
        /// Checks if an object is being examined and initiates the examination process.
        /// </summary>
        /// <param name="hitGameObject">The GameObject being examined.</param>
        public void CheckExamining(GameObject hitGameObject)
        {
            currentInspectItemBehaviour = hitGameObject.GetComponent<ItemBehaviour>();
            inspectItemData.ToggleExamination();

            // Store the currently examined object and its original position and rotation
            if (inspectItemData.IsExamining)
            {
                currentInspectItemBehaviour.StopScaleTween();
                inspectItemData.ExaminedObject = hitGameObject.transform;
                inspectItemData.OriginalPositions[inspectItemData.ExaminedObject] = inspectItemData.ExaminedObject.position;
                inspectItemData.OriginalRotations[inspectItemData.ExaminedObject] = inspectItemData.ExaminedObject.rotation;
            }
        }

        private void Update()
        {
            // Checks if the player is examining an object and updates the UI accordingly.
            if (inspectItemData.IsExamining)
            {
                Examine();
                togglePromptTextGameEvent.Raise(false);
                examineCanvas.SetActive(true);

                if (!levelPreferencesData.TutorialSelected)
                {
                    englishText.SetActive(false);
                }

                if (levelPreferencesData.TutorialSelected)
                {
                    setTutorialTextGameEvent.Raise(currentInspectItemBehaviour.MultiLingualData.EnglishLanguageData.LanguageText + ":" + "\n" +
                                                   currentInspectItemBehaviour.MultiLingualData.CurrentLanguageToLearnData.LanguageText);
                }
            }
            else
            {
                NonExamine();

                if (levelPreferencesData.TutorialSelected)
                {
                    setTutorialTextGameEvent.Raise("");
                }

                examineCanvas.SetActive(false);
            }
        }

        /// <summary>
        /// Handles the examination behaviour, including object movement and rotation.
        /// </summary>
        private void Examine()
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

        /// <summary>
        /// Handles behavior when not examining, including resetting the object's position and rotation.
        /// </summary>
        private void NonExamine()
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

        /// <summary>
        /// Checks for player input during examination and triggers corresponding actions.
        /// </summary>
        private void CheckPlayerInput()
        {
            if (levelPreferencesData.TutorialSelected)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    SoundManager.Instance.PlayOneShotSound(currentInspectItemBehaviour.MultiLingualData.EnglishLanguageData.TextToSpeech);
                }
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                SoundManager.Instance.PlayOneShotSound(currentInspectItemBehaviour.MultiLingualData.CurrentLanguageToLearnData.TextToSpeech);
            }

            else if (Input.GetKeyDown(KeyCode.A))
            {
                currentInspectItemBehaviour.DeleteItem();
                addToInventoryGameEvent.Raise(currentInspectItemBehaviour.MultiLingualData);
                inspectItemData.ToggleExamination();
            }
        }

        #endregion
    }
}
