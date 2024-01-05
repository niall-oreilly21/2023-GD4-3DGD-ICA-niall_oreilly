using UnityEngine;

namespace My_Assets.Scripts.Managers
{
    [System.Serializable]
    public class MultiUIComponent : UIComponent
    {
        [SerializeField] 
        private Transform itemContentTwo;
        public Transform ItemContentTwo => itemContentTwo;
    }
}