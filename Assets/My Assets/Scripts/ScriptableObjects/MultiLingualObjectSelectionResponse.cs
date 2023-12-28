using GD.Selection;
using UnityEngine;

namespace My_Assets.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "MultiLingualObjectSelectionResponse", menuName = "DkIT/Scriptable Objects/Other/Responses/MultiLingualObject")]
    public class MultiLingualObjectSelectionResponse : ScriptableObject, ISelectionResponse
    {
        public void OnDeselect(Transform selection)
            {
              selection.gameObject.SetActive(true);
            }

            public void OnSelect(Transform selection)
            {
                selection.gameObject.SetActive(false);
            }
    }
}