using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneFader : MonoBehaviour
{
    private Image sceneFadeImage;

    private void Awake()
    {
        sceneFadeImage = GetComponent<Image>();
    }

    // Call this method to start fading in the scene
    public IEnumerator FadeInCoroutine(float duration)
    {
       Color startColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 1f);
       Color targetColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 0f);

       yield return FadeCoroutine(startColor, targetColor, duration);

       gameObject.SetActive(false);
    }

    // This method is used to fade out the scene. It sets the starting color to fully transparent and the target color to fully opaque, then starts the fade coroutine.
    public IEnumerator FadeOutCoroutine(float duration)
    {
        Color startColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 0f);
        Color targetColor = new Color(sceneFadeImage.color.r, sceneFadeImage.color.g, sceneFadeImage.color.b, 1f);

        gameObject.SetActive(true); 
        yield return FadeCoroutine(startColor, targetColor, duration);
    }

    private IEnumerator FadeCoroutine(Color startColor, Color targetColor, float duration)
    {
        float elapsedTime = 0f;
        float elapsedPercentage = 0f;

        while (elapsedPercentage < 1f)
        {
            elapsedPercentage = elapsedTime / duration;
            sceneFadeImage.color = Color.Lerp(startColor, targetColor, elapsedPercentage);
    
            yield return null;
            elapsedTime += Time.deltaTime;
        }

        sceneFadeImage.color = targetColor;
    }
}
