using UnityEngine;
using UnityEngine.EventSystems;

public class TextClickFeedback_text : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Vector3 clickedScale = new Vector3(1.1f, 1.1f, 1f);
    public float feedbackDuration = 0.1f;

    private Vector3 defaultScale; // Will store the original scale of the object
    private Coroutine currentFeedbackCoroutine = null;

    private void Awake()
    {
        defaultScale = transform.localScale; // Store the original scale
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (currentFeedbackCoroutine != null)
        {
            StopCoroutine(currentFeedbackCoroutine);
        }
        currentFeedbackCoroutine = StartCoroutine(FeedbackEffect());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (currentFeedbackCoroutine != null)
        {
            StopCoroutine(currentFeedbackCoroutine);
            transform.localScale = defaultScale; // Reset to the original scale
        }
    }

    private System.Collections.IEnumerator FeedbackEffect()
    {
        transform.localScale = clickedScale;
        yield return new WaitForSecondsRealtime(feedbackDuration);
        transform.localScale = defaultScale;
    }
}
