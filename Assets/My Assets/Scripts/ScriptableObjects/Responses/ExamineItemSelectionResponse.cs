using GD;
using GD.Selection;
using My_Assets.Scripts.Behaviours;
using My_Assets.Scripts.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ExamineItemSelectionResponse", menuName = "DkIT/Scriptable Objects/Other/Responses/ExamineItem")]
    public class ExamineItemSelectionResponse : ScriptableObject, ISelectionResponse
    {
        [FormerlySerializedAs("examineObject")] [SerializeField]
        private GameObjectGameEvent examineObjectGameEvent;
        
        [SerializeField]
        private GameObjectGameEvent checkInRange;

        [SerializeField]
        private BoolVariable isCollidingWithCurrentObject;
        
        [SerializeField]
        private BoolGameEvent togglePromptTextGameEvent;

        [SerializeField] 
        private InspectItemData inspectItemData;
        
            public void OnDeselect(Transform selection)
            {
                if (!inspectItemData.IsExamining)
                {
                    isCollidingWithCurrentObject.Value = false;
                    togglePromptTextGameEvent.Raise(false);
                }
            }
            public void OnSelect(Transform selection)
            {
                checkInRange.Raise(selection.gameObject);

                if (isCollidingWithCurrentObject.Value)
                {
                    if (!inspectItemData.IsExamining)
                    {
                        togglePromptTextGameEvent.Raise(true);
                    }
                    
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        examineObjectGameEvent.Raise(selection.gameObject);
                    }
                }
            }
    }
}