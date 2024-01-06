using System.Collections.Generic;
using GD;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects.Inspect
{
    [CreateAssetMenu(fileName = "GameLevel", menuName = "DkIT/Scriptable Objects/Game/InspectItem", order = 1)]
    public class InspectItemData : BaseObjectData
    {
        #region Fields
        
        /// <summary>
        /// State of whether the player is inspecting or not.
        /// </summary>
        private bool isExamining = false;
        
        /// <summary>
        /// The last recorded mouse position during examination.
        /// </summary>
        private Vector3 lastMousePosition;

        /// <summary>
        /// The currently examined object during examination.
        /// </summary>
        private Transform examinedObject;

        /// <summary>
        /// Original positions of interactable objects
        /// </summary>
        private Dictionary<Transform, Vector3> originalPositions = new Dictionary<Transform, Vector3>();

        /// <summary>
        /// Original rotations of interactable objects
        /// </summary>
        private Dictionary<Transform, Quaternion> originalRotations = new Dictionary<Transform, Quaternion>();
        
        #endregion
        
        
        #region Properties
        public bool IsExamining
        {
            get => isExamining;
            set => isExamining = value;
        }
        public Vector3 LastMousePosition
        {
            get => lastMousePosition;
            set => lastMousePosition = value;
        }
        public Transform ExaminedObject
        {
            get => examinedObject;
            set => examinedObject = value;
        }
        public Dictionary<Transform, Vector3> OriginalPositions => originalPositions;
        public Dictionary<Transform, Quaternion> OriginalRotations => originalRotations;
        #endregion
        
        /// <summary>
        /// Change the state of examining.
        /// </summary>
        public void ToggleExamination()
        {
            isExamining = !isExamining;
        }
    }
}