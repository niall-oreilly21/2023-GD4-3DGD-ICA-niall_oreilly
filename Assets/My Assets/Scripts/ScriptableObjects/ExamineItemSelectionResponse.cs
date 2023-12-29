using GD;
using GD.Selection;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ExamineItemSelectionResponse", menuName = "DkIT/Scriptable Objects/Other/Responses/ExamineItem")]
    public class ExamineItemSelectionResponse : ScriptableObject, ISelectionResponse
    {
        [SerializeField]
        private GameObjectGameEvent examineObject;
            public void OnDeselect(Transform selection)
            {
            }

            public void OnSelect(Transform selection)
            {
                Debug.Log("HERER");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    examineObject.Raise(selection.gameObject);
                }
            }
    }
}