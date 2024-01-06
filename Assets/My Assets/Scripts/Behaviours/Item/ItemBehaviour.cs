using DG.Tweening;
using My_Assets.Scripts.ScriptableObjects;
using My_Assets.Scripts.ScriptableObjects.Languages;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.Item
{
    /// <summary>
   /// Unity MonoBehaviour for handling the behavior of items, including scaling and deletion.
   /// </summary>
    public class ItemBehaviour : MonoBehaviour
    {
        #region Fields

        [SerializeField]
        [Tooltip("The initial scale of the object.")]
        private float startScale = 1f;

        [SerializeField]
        [Tooltip("The target scale for the object.")]
        private float targetScale = 0.5f;

        [SerializeField]
        [Tooltip("The duration of the scaling tween.")]
        private float tweenDuration = 1f;

        [SerializeField]
        [Tooltip("The multilingual data associated with the object.")]
        private MultiLingualData multiLingualData;

        private Material material;
        private Sequence scaleTweenSequence;
        private BoxCollider currentBoxCollider;
        
        #endregion

        #region Properties

        public MultiLingualData MultiLingualData => multiLingualData;

        #endregion

        private void Start()
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null && renderer.materials.Length > 0)
            {
                material = renderer.materials[0];
            }

            startScale = transform.localScale.x;
            targetScale = startScale * 2;

            currentBoxCollider = GetComponent<BoxCollider>();

            StartScaleTween();
        }

        public void StartScaleTween()
        {
            currentBoxCollider.size = new Vector3(0.5f, 0.5f, 0.5f);
            
            // Reset the scale to the starting scale (optional)
            transform.localScale = new Vector3(startScale, startScale, startScale);
            
            //DOTween to tween the object's scale
            scaleTweenSequence = DOTween.Sequence();
            scaleTweenSequence.Append(transform.DOScale(targetScale, tweenDuration * 0.5f).SetEase(Ease.OutQuad));
            scaleTweenSequence.Join(material.DOColor(Color.yellow * 2, "_EmissionColor", tweenDuration * 0.5f));
            
            scaleTweenSequence.Append(transform.DOScale(startScale, tweenDuration * 0.5f).SetEase(Ease.InQuad));
            scaleTweenSequence.Join(material.DOColor(Color.black, "_EmissionColor", tweenDuration * 0.5f));
            
            //Infinite loop (grows and shrinks continuously)
            scaleTweenSequence.SetLoops(-1);
        }

        public void StopScaleTween()
        {
            currentBoxCollider.size = new Vector3(0.5f, 0.5f, 0.5f);
            if (scaleTweenSequence != null && scaleTweenSequence.IsActive())
            {
                scaleTweenSequence.Kill();
                material.DOColor(Color.black, "_EmissionColor", 0.1f);
            }
        }

        public void DeleteItem()
        {
            Destroy(gameObject);
        }
    }
}