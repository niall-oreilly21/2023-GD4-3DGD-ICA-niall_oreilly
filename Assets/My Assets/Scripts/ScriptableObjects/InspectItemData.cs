using System.Collections.Generic;
using GD;
using Sirenix.OdinInspector;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "GameLevel", menuName = "DkIT/Scriptable Objects/Game/InspectItem", order = 1)]
    public class InspectItemData : BaseObjectData
    {
        [SerializeField]
        [Tooltip("The GameObject offset used during examination.")]
        private GameObject offset;

        [SerializeField]
        [Searchable]
        [Tooltip("The Canvas used for examination UI.")]
        private Canvas interactingCanvas;

        [SerializeField]
        [Searchable]
        [Tooltip("The Canvas used for examination UI (alternative reference).")]
        private Canvas examineCanvas;

        [SerializeField]
        private EnumGameEvent itemLanguageToPlay;
        
        #region Properties
        private bool isExamining = false;
        public GameObject Offset => offset;
        public Canvas InteractingCanvas => interactingCanvas;
        public Canvas ExamineCanvas => examineCanvas;
        public bool IsExamining => isExamining;
        
        public EnumGameEvent ItemLanguageToPlay => itemLanguageToPlay;
        #endregion
        
        public void ToggleExamination()
        {
            isExamining = !isExamining;
        }
    }
}