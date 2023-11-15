using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class UISceneController : MonoBehaviour
{
    public RectTransform[] backgrounds;
    public Image fadeOverlay; // The UI Image used for the fade effect
    public float fadeDuration = 2.0f; 
    public float speed = 5.0f;
    public float backgroundWidth = 871.8356f; 

    private void Start()
    {
        // Start with the fade overlay fully visible
        fadeOverlay.color = new Color(0, 0, 0, 1);
        fadeOverlay.gameObject.SetActive(true);
        StartCoroutine(FadeOut());
    }

    void Update()
    {
        // Move each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            MoveBackground(backgrounds[i]);
        }
    }

    void MoveBackground(RectTransform background)
    {
        // Calculate the new position
        float newX = background.anchoredPosition.x - (speed * Time.deltaTime);
        background.anchoredPosition = new Vector2(newX, background.anchoredPosition.y);

        if (background.anchoredPosition.x <= -backgroundWidth)
        {
            Vector2 newPosition = new Vector2(
                background.anchoredPosition.x + 2 * backgroundWidth,
                background.anchoredPosition.y
            );
            background.anchoredPosition = newPosition;
        }
    }

    IEnumerator FadeOut()
    {
        float elapsed = 0;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, elapsed / fadeDuration);
            fadeOverlay.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
        fadeOverlay.color = new Color(0, 0, 0, 0); 
        fadeOverlay.gameObject.SetActive(false); 
    }
}
