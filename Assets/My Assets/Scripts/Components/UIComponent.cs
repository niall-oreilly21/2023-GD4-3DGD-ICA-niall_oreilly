using TMPro;
using UnityEngine;

namespace My_Assets.Scripts.Components
{
    /// <summary>
    /// Serializable base class representing a UI component with basic properties.
    /// </summary>
    [System.Serializable]
    public class UIComponent
    {
        #region Fields

        [SerializeField]
        [Tooltip("The UI item GameObject.")]
        private GameObject uiItem;

        [SerializeField] 
        [Tooltip("The item content Transform.")]
        private Transform itemContent;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the item content transform.
        /// </summary>
        public Transform ItemContent => itemContent;

        /// <summary>
        /// Gets the UI item GameObject.
        /// </summary>
        public GameObject UiItem => uiItem;

        #endregion

        /// <summary>
        /// Sets up the TextMeshPro reference within the UI component.
        /// </summary>
        /// <param name="newUIComponent">The new UI component GameObject.</param>
        /// <param name="text">The text to set in the TextMeshPro component.</param>
        public void SetUpTextReference(GameObject newUIComponent, string text)
        {
            // Try to find TextMeshPro component anywhere in the hierarchy under newUIComponent
            TextMeshProUGUI textMeshPro = newUIComponent.GetComponentInChildren<TextMeshProUGUI>(true);

            if (textMeshPro != null)
            {
                textMeshPro.text = text;
            }
            else
            {
                Debug.LogWarning("TextMeshPro component not found under " + newUIComponent.name);
            }
        }
    }
}