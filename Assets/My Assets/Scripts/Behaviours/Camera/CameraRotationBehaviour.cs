using System.Collections;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.Camera
{
    /// <summary>
    /// Unity MonoBehaviour to rotate a camera using a coroutine.
    /// </summary>
    public class CameraRotationBehaviour : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        [Tooltip("The total time taken to complete the rotation.")]
        [Range(0f, 5f)]
        private float totalRotationTime;

        [SerializeField]
        [Tooltip("The rotation applied to the camera.")]
        private Vector3 rotation;

        private bool isRotating;

        #endregion

        private void Start()
        {
            isRotating = false;
        }

        /// <summary>
        /// Initiates the camera rotation if it is not already rotating.
        /// </summary>
        public void RotateCamera()
        {
            if (!isRotating)
            {
                StartCoroutine(RotateCameraCoroutine());
            }
        }

        private IEnumerator RotateCameraCoroutine()
        {
            isRotating = true;

            Vector3 startEulerAngles = transform.eulerAngles;
            Vector3 targetEulerAngles = startEulerAngles + rotation;

            float elapsedTime = 0f;

            while (elapsedTime < totalRotationTime)
            {
                transform.rotation = Quaternion.Euler(Vector3.Slerp(startEulerAngles, targetEulerAngles, elapsedTime / totalRotationTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            transform.rotation = Quaternion.Euler(targetEulerAngles);

            isRotating = false;
        }

    }
}