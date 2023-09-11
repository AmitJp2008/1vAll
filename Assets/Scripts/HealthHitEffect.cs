using System.Collections;
using UnityEngine;

public class HealthHitEffect : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;     
    [SerializeField] private float startingOpacity;
    [SerializeField] private float duration = 0.1f;
    
    public void Playffect() 
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeOutCanvasGroup());
    }

    public IEnumerator FadeOutCanvasGroup()
    {
        // Store the initial alpha value to interpolate from
        float startAlpha = startingOpacity;

        // Target alpha value (0 for fading out)
        float targetAlpha = 0f;

        // Variable to hold the elapsed time
        float elapsedTime = 0f;

        // Loop to interpolate alpha
        while (elapsedTime < duration)
        {
            // Update elapsed time
            elapsedTime += Time.deltaTime;

            // Interpolate alpha value
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / duration);

            // Set the new alpha value
            canvasGroup.alpha = newAlpha;

            yield return null;  // Skip to the next frame
        }

        // Make sure the target alpha is set
        canvasGroup.alpha = targetAlpha;
        gameObject.SetActive(false);
    }
}
