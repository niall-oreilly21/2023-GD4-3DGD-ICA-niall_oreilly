using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours
{
    public class SliderUITextController : MonoBehaviour
    {
        [SerializeField]
        private Slider countOfWordsSlider;

        [SerializeField]
        private TextMeshProUGUI countOfWordsText;

        public void SetCountOfWordsText()
        {
            countOfWordsText.SetText(countOfWordsSlider.value.ToString());
        }
    }
}