using TMPro;
using UnityEngine;

namespace My_Assets.Scripts.Managers
{
    [System.Serializable]
    public class UIComponent
    {
        [SerializeField]
        private GameObject uiItem;
        
        [SerializeField] 
        private Transform itemContent;

        public Transform ItemContent => itemContent;
        public GameObject UiItem => uiItem;

        public void SetUpTextReference(GameObject newUIComponent, string text)
        {
            // Try to find TextMeshPro component anywhere in the hierarchy under newUIComponent
            TextMeshProUGUI textMeshPro = newUIComponent.GetComponentInChildren<TextMeshProUGUI>(true);

            if (textMeshPro != null)
            {
                textMeshPro.text = text;
            }
            else
            {
                Debug.LogWarning("TextMeshPro component not found under " + newUIComponent.name);
            }
        }
    }
}