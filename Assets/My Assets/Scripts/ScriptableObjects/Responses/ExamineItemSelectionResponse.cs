using GD;
using GD.Selection;
using My_Assets.Scripts.Behaviours;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ExamineItemSelectionResponse", menuName = "DkIT/Scriptable Objects/Other/Responses/ExamineItem")]
    public class ExamineItemSelectionResponse : ScriptableObject, ISelectionResponse
    {
        [SerializeField]
        private GameObjectGameEvent examineObject;
        
        [SerializeField]
        private GameObjectGameEvent checkInRange;

        [SerializeField]
        private BoolVariable isCollidingWithCurrentObject;

        [SerializeField] 
        private InspectItemData inspectItemData;
        
            public void OnDeselect(Transform selection)
            {
                if (!inspectItemData.IsExamining)
                {
                    isCollidingWithCurrentObject.Value = false;
                }
            }
            public void OnSelect(Transform selection)
            {
                checkInRange.Raise(selection.gameObject);
                
                if (isCollidingWithCurrentObject.Value)
                {
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        examineObject.Raise(selection.gameObject);
                    }
                }
            }
    }
}