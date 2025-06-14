using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class LoadingWater : MonoBehaviour
{
    [SerializeField] private List<Sprite> idleAnimation;
    [SerializeField] private float frameRate = 10f;

    private Image image;
    private int currentFrame;
    private float timer;

    private void Start()
    {
        image = GetComponent<Image>();
        if (idleAnimation.Count > 0)
            StartCoroutine(PlayIdleAnimation());
    }

    private IEnumerator PlayIdleAnimation()
    {
        float delay = 1f / frameRate;

        while (true)
        {
            if (idleAnimation.Count == 0) yield break;

            image.sprite = idleAnimation[currentFrame];
            currentFrame = (currentFrame + 1) % idleAnimation.Count;
            yield return new WaitForSeconds(delay);
        }
    }
}
