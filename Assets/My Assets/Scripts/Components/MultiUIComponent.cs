using UnityEngine;

namespace My_Assets.Scripts.Components
{
    /// <summary>
    /// Serializable class representing a multi-part UI component with additional item content.
    /// </summary>
    [System.Serializable]
    public class MultiUIComponent : UIComponent
    {
        #region Fields

        [SerializeField] 
        [Tooltip("The additional item content Transform.")]
        private Transform itemContentTwo;

        #endregion

        #region Properties

        /// <summary>
        /// Gets the additional item content.
        /// </summary>
        public Transform ItemContentTwo => itemContentTwo;

        #endregion
    }
}