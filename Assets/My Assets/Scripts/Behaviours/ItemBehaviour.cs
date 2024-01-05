using System;
using DG.Tweening;
using GD;
using My_Assets.Scripts.Behaviours;
using My_Assets.Scripts.ScriptableObjects;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace My_Assets.Scripts
{
    
   using UnityEngine;
using DG.Tweening;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField] 
    private float startScale = 1f;
    
    [SerializeField] 
    private float targetScale = 0.5f;
    
    [SerializeField] 
    private float tweenDuration = 1f;

    [SerializeField]
    private MultiLingualData multiLingualData;

    private Material material;
    private Sequence scaleTweenSequence;
    private BoxCollider currentBoxCollider;
    

    public MultiLingualData MultiLingualData => multiLingualData;

    private void Start()
    {
        // Assuming your object has a renderer and the material you want to modify is the first material in the list
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null && renderer.materials.Length > 0)
        {
            material = renderer.materials[0];
        }

        startScale = transform.localScale.x;
        targetScale = startScale * 2;

        currentBoxCollider = GetComponent<BoxCollider>();

        // Call the method to start the tween
        StartScaleTween();
    }

    public void StartScaleTween()
    {
        currentBoxCollider.size = new Vector3(0.5f, 0.5f, 0.5f);
        // Reset the scale to the starting scale (optional)
        transform.localScale = new Vector3(startScale, startScale, startScale);
        
        // Use DOTween to tween the object's scale
        scaleTweenSequence = DOTween.Sequence();
        scaleTweenSequence.Append(transform.DOScale(targetScale, tweenDuration * 0.5f).SetEase(Ease.OutQuad));
        scaleTweenSequence.Join(material.DOColor(Color.yellow * 2, "_EmissionColor", tweenDuration * 0.5f));
        
        scaleTweenSequence.Append(transform.DOScale(startScale, tweenDuration * 0.5f).SetEase(Ease.InQuad));
        scaleTweenSequence.Join(material.DOColor(Color.black, "_EmissionColor", tweenDuration * 0.5f));
        
        // Infinite loop (grows and shrinks continuously)
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