using UnityEngine;

namespace GD.Selection
{
    [CreateAssetMenu(fileName = "SO_TargetSelectionResponse",
      menuName = "DkIT/Scriptable Objects/Responses/Target")]
    public class SO_TargetSelectionResponse : ScriptableGameObject, ISelectionResponse
    {
        [SerializeField]
        [Tooltip("Set prefab object used for target highlighting")]
        private GameObject targetSelectionPrefab;

        [SerializeField]
        private LayerMask targetGroundLayerMask;

        [SerializeField]
        [Tooltip("Vertical offset on target highlight above ground layer")]
        private float targetOffset;

        private GameObject currentTargetInstance;
        private float scaleFactor = 5;
        private int rayCastDepth = 10;

        public void Awake()
        {
            //currentTargetInstance = Instantiate(targetSelectionPrefab,
            //    Vector3.zero, Quaternion.Euler(0, 0, 0));
            //currentTargetInstance.SetActive(false);

            currentTargetInstance = null;
        }

        public void OnSelect(Transform selection)
        {
            if (selection != null)
            {
                RaycastHit hitInfo;
                //figure out how far away is the ground
                if (Physics.Raycast(selection.position, -selection.up,
                    out hitInfo, rayCastDepth, targetGroundLayerMask))
                {
                    //do we have an target instance? if not and valid prefab then instantiate
                    if (currentTargetInstance == null && targetSelectionPrefab != null)
                        currentTargetInstance = Instantiate(targetSelectionPrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));

                    //move the target down to be just above ground
                    currentTargetInstance.transform.position
                        = selection.position - new Vector3(0, hitInfo.distance - targetOffset, 0);
                    //work out scale factor for highlight
                    float mag
                        = selection.GetComponent<Collider>().bounds.size.magnitude / scaleFactor;
                    //scale the target down to suit the object being selected
                    currentTargetInstance.transform.localScale
                        = new Vector3(mag, mag, mag);
                    currentTargetInstance.SetActive(true);
                }
            }
        }

        public void OnDeselect(Transform selection)
        {
            currentTargetInstance.SetActive(false);
        }
    }
}