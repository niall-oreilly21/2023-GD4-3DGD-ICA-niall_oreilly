using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours
{
    public class SliderUIMaxCountController : MonoBehaviour
    {
        [SerializeField]
        private Slider sourceSlider;
        
        [SerializeField]
        private Slider targetSlider;

        public void Update()
        {
            SetMaxCountOfWordsToTest();
        }

        public void SetMaxCountOfWordsToTest()
        {
            targetSlider.maxValue = sourceSlider.value;
        }
    }
}