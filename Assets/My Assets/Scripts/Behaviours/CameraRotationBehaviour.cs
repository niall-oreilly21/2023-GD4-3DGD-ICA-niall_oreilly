using System;
using System.Collections;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours
{
    public class CameraRotationBehaviour : MonoBehaviour
    {
        [SerializeField] 
        [Range(0f, 5f)]
        private float totalRotationTime;
        
        [SerializeField]
        private Vector3 rotation;
        
        private bool isRotating;

        private void Start()
        {
            isRotating = false;
        }
        
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

            Quaternion startRotation = transform.rotation;
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