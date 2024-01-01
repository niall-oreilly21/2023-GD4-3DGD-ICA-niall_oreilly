using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace My_Assets.Scripts.Behaviours
{
    public class SliderUITextController : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;

        [SerializeField]
        private TextMeshProUGUI text;

        public void SetCountOfWordsText()
        {
            text.SetText(slider.value.ToString());
        }
    }
}