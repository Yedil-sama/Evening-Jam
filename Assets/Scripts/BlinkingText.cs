using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class BlinkingText : MonoBehaviour
{
    [SerializeField] private float blinkSpeed = 1f;

    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void Update()
    {
        canvasGroup.alpha = Mathf.PingPong(Time.time * blinkSpeed, 1f);
    }
}
