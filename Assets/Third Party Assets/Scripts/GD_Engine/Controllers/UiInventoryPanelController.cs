using DG.Tweening;
using GD;
using Sirenix.OdinInspector;
using UnityEngine;


namespace Third_Party_Assets.Scripts.GD_Engine.Controllers
{
    public class UIInventoryPanelController : MonoBehaviour
{
    [SerializeField]
    private RectTransform inventoryPanelTransform;

    [SerializeField]
    [AudioClipButton]
    private AudioClip openAudioClip, closeAudioClip;

    [SerializeField]
    [Range(0, 10)]
    [Unit(Units.Second)]
    private float translationDuration = 1;

    [SerializeField]
    private Vector2 translationVector = new Vector2(0, -100);

    [SerializeField]
    private Ease translationEaseFunction = Ease.InOutSine;

    [SerializeField]
    [ReadOnly]
    private ActivationStateType activationStateType = ActivationStateType.Closed;

    private Vector3 startPosition;
    private AudioSource audioSource;

    private void Awake()
    {
        startPosition = inventoryPanelTransform.localPosition;

        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    public void TogglePanel()
    {
        //if closed, then open
        if (activationStateType == ActivationStateType.Closed)
        {
            activationStateType = ActivationStateType.Opening;

            audioSource.clip = openAudioClip;
            audioSource.Play();

            inventoryPanelTransform.DOLocalMove(startPosition + new Vector3(translationVector.x, translationVector.y, 0), translationDuration)
                .SetEase(translationEaseFunction)
                .OnComplete(() => activationStateType = ActivationStateType.Open);
        }
        //if open, then close
        else if (activationStateType == ActivationStateType.Open)
        {
            activationStateType = ActivationStateType.Closing;

            audioSource.clip = closeAudioClip;
            audioSource.Play();

            inventoryPanelTransform.DOLocalMove(startPosition, translationDuration)
               .SetEase(translationEaseFunction)
               .OnComplete(() => activationStateType = ActivationStateType.Closed);
        }
    }
}
}