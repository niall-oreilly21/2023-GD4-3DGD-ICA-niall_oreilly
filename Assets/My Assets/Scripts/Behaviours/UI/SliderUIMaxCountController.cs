using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours
{
    /// <summary>
    /// Unity MonoBehaviour for synchronizing the maximum value of one slider to another.
    /// </summary>
    public class SliderUIMaxCountController : MonoBehaviour
    {
        #region Fields
        [SerializeField]
        [Tooltip("Slider serving as the source of the maximum value.")]
        private Slider sourceSlider;
        
        [SerializeField]
        [Tooltip("Slider whose maximum value is synchronized with the source slider.")]
        private Slider targetSlider;
        #endregion
        
        public void Update()
        {
            SetMaxCountOfWordsToTest();
        }

        /// <summary>
        /// Updates the maximum value of the target slider based on the value of the source slider.
        /// </summary>
        private void SetMaxCountOfWordsToTest()
        {
            targetSlider.maxValue = sourceSlider.value;
        }
    }
}