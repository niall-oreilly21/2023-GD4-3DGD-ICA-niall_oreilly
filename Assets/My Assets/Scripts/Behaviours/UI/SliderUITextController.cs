using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours
{
    /// <summary>
    /// Unity MonoBehaviour for updating a TextMeshProUGUI component with the value of a slider.
    /// </summary>
    public class SliderUITextController : MonoBehaviour
    {
        #region Fields
        
        [SerializeField]
        [Tooltip("Slider whose value will be displayed in the TextMeshProUGUI component.")]
        private Slider slider;

        [SerializeField]
        [Tooltip("TextMeshProUGUI component to display the slider's value.")]
        private TextMeshProUGUI text;
        
        #endregion

        /// <summary>
        /// Sets the TextMeshProUGUI component's text to the current value of the slider.
        /// </summary>
        public void SetCountOfWordsText()
        {
            text.SetText(slider.value.ToString());
        }
    }
}