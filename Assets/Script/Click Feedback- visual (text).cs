using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextClickVisualFeedback : MonoBehaviour
{
    public Color defaultColor = Color.white;
    public Color onClickColor = Color.red;
    public float feedbackDuration = 0.2f;
    public Vector3 enlargementScale = new Vector3(1.1f, 1.1f, 1.1f); // New addition

    private Text textComponent;
    private Vector3 originalScale; // New addition

    private void Awake()
    {
        textComponent = GetComponent<Text>();
        originalScale = transform.localScale; // New addition
    }

    public void ShowVisualFeedback()
    {
        StartCoroutine(VisualFeedbackCoroutine());
    }

    private IEnumerator VisualFeedbackCoroutine()
    {
        textComponent.color = onClickColor;
        transform.localScale = enlargementScale; // New addition
        yield return new WaitForSeconds(feedbackDuration);
        textComponent.color = defaultColor;
        transform.localScale = originalScale; // New addition
    }
}
