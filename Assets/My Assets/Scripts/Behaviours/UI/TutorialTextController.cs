using System;
using TMPro;
using UnityEngine;

namespace My_Assets.Scripts.Behaviours.UI
{
    public class TutorialTextController : MonoBehaviour
    {
        [SerializeField] 
        private GameObject container;
        
        [SerializeField]
        private TextMeshProUGUI textMesh;

        public void SetText(string text)
        {
            if (text.Equals(""))
            {
                container.SetActive(false);
            }
            else
            {
                container.SetActive(true);
            }
            textMesh.SetText(text);
        }
    }
}