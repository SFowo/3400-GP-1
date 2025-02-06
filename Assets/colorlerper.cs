using System.Collections;
using UnityEngine;

public class ColorLerper : MonoBehaviour
{
    [SerializeField] private Renderer targetRenderer;
    [SerializeField] private float lerpDuration = 2f;

    private Color startColor;
    public Color targetColor = Color.red;
    private bool isLerpingToRed = true;
    private float lerpTime;
    private bool isLerpingActive = true;

    void Start()
    {
        if (targetRenderer == null)
        {
            targetRenderer = GetComponent<Renderer>();
        }
        startColor = targetRenderer.material.color;
    }

    void Update()
    {
        if (!isLerpingActive) return;

        lerpTime += Time.deltaTime / lerpDuration;

        if (isLerpingToRed)
        {
            targetRenderer.material.color = Color.Lerp(startColor, targetColor, lerpTime);
        }
        else
        {
            targetRenderer.material.color = Color.Lerp(targetColor, startColor, lerpTime);
        }

        if (lerpTime >= 1f)
        {
            lerpTime = 0f;
            isLerpingToRed = !isLerpingToRed;
        }
    }

    public void StopLerping()
    {
        isLerpingActive = false;
    }
}