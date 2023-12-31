using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours
{
    public class SliderUIMaxCountOfWordsToTestController : MonoBehaviour
    {
        [SerializeField]
        private Slider countOfWordsToLearn;
        
        [SerializeField]
        private Slider countOfWordsToTest;

        public void SetMaxCountOfWordsToTest()
        {
            countOfWordsToTest.maxValue = countOfWordsToLearn.value;
        }
    }
}