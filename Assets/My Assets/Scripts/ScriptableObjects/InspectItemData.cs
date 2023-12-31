using System.Collections.Generic;
using GD;
using Sirenix.OdinInspector;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameLevel", menuName = "DkIT/Scriptable Objects/Game/InspectItem", order = 1)]
    public class InspectItemData : BaseObjectData
    {
        private bool isExamining = false;
        
        //The last recorded mouse position during examination.
        private Vector3 lastMousePosition;

        //The currently examined object during examination.
        private Transform examinedObject;

        //Original positions of interactable objects
        private Dictionary<Transform, Vector3> originalPositions = new Dictionary<Transform, Vector3>();

        //Original rotations of interactable objects
        private Dictionary<Transform, Quaternion> originalRotations = new Dictionary<Transform, Quaternion>();

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
        public void ToggleExamination()
        {
            isExamining = !isExamining;
        }
    }
}