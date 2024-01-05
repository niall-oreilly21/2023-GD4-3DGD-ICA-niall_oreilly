using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace My_Assets.Scripts.Behaviours
{
    public class GlowEffect : MonoBehaviour
    {
        [SerializeField] private Color glowColor = Color.white;
        [SerializeField, Range(0.1f, 5f)] private float glowIntensity = 1f;

        private Material originalMaterial;
        private Material glowMaterial;
        private PostProcessVolume postProcessVolume;
        private Bloom bloomLayer;

        private void Start()
        {
            // Store the original material of the object
            originalMaterial = GetComponent<Renderer>().material;

            // Create a copy of the original material for glowing
            glowMaterial = new Material(originalMaterial);
            glowMaterial.EnableKeyword("_EMISSION");

            // Initialize post-processing components
            postProcessVolume = gameObject.GetComponent<PostProcessVolume>();
            if (postProcessVolume == null)
                postProcessVolume = gameObject.AddComponent<PostProcessVolume>();

            postProcessVolume.profile = ScriptableObject.CreateInstance<PostProcessProfile>();
            bloomLayer = postProcessVolume.profile.AddSettings<Bloom>();
        }

        public void StartGlow()
        {
            // Apply the glow material to make the object glow
            GetComponent<Renderer>().material = glowMaterial;
            glowMaterial.SetColor("_EmissionColor", glowColor * glowIntensity);

            // Ensure that bloomLayer is not null
            if (bloomLayer != null)
                bloomLayer.enabled.value = true;
        }

        public void StopGlow()
        {
            // Revert to the original material to stop glowing
            GetComponent<Renderer>().material = originalMaterial;

            // Ensure that bloomLayer is not null
            if (bloomLayer != null)
                bloomLayer.enabled.value = false;
        }
    }



}