using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UISceneController : MonoBehaviour
{
    public RectTransform background;     // The moving background
    public float speed = 1.0f; // Speed at which the background moves
    public bool loopBackground = true; // Should the background loop?
    public float loopPoint; // At which point should the background loop?

    private Vector2 originalPosition;

    void Start()
    {
        originalPosition = background.anchoredPosition;
    }

    void Update()
    {
        MoveBackground();
    }

    void MoveBackground()
    {
        Vector2 newPosition = background.anchoredPosition + new Vector2(-speed, 0) * Time.deltaTime;
        background.anchoredPosition = newPosition;

        // If the background should loop and it's reached its loop point, reset its position
        if (loopBackground && background.anchoredPosition.x <= loopPoint)
        {
            background.anchoredPosition = originalPosition;
        }
    }
}
