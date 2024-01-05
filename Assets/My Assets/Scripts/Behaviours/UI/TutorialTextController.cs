using System;
using TMPro;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.UI
{
    
    /// <summary>
    /// Unity MonoBehaviour that controls the display of tutorial text in a Unity scene.
    /// </summary>
    public class TutorialTextController : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        private GameObject container;

        [SerializeField]
        private TextMeshProUGUI textMesh;

        #endregion

        /// <summary>
        /// Sets the TextMeshProUGUI component's text based on the provided string.
        /// If the string is empty, hides the container; otherwise, shows it.
        /// </summary>
        /// <param name="text">Text to be displayed.</param>
        public void SetText(string text)
        {
            if (text.Equals(""))
            {
                container.SetActive(false);
            }
            else
            {
                container.SetActive(true);
            }
            textMesh.SetText(text);
        }
    }
}