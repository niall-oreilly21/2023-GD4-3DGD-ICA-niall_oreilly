using UnityEngine;

namespace GD.Selection
{
    [CreateAssetMenu(fileName = "SO_SoundSelectionResponse",
        menuName = "DkIT/Scriptable Objects/Responses/Sound")]
    public class SO_SoundSelectionResponse : ScriptableGameObject, ISelectionResponse
    {
        [SerializeField]
        private AudioClip selectedAudioClip;

        private Transform currentTransform = null;

        public void OnDeselect(Transform transform)
        {
        }

        public void OnSelect(Transform transform)
        {
            if (currentTransform != null && currentTransform != transform)
                AudioSource.PlayClipAtPoint(selectedAudioClip, transform.position);
            currentTransform = transform;
        }
    }
}