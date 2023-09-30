using UnityEngine;

public class UISceneController : MonoBehaviour
{
    public RectTransform[] backgrounds; // Array of the moving backgrounds
    public float speed = 1.0f; // Speed at which the backgrounds move
    public float backgroundWidth; // Width of the background images

    private Vector2[] originalPositions;

    void Start()
    {
        // Initialize the originalPositions array with the same length as backgrounds
        originalPositions = new Vector2[backgrounds.Length];

        // Store the original position of each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            originalPositions[i] = backgrounds[i].anchoredPosition;
        }
    }

    void Update()
    {
        // Move each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            MoveBackground(backgrounds[i], originalPositions[i]);
        }
    }

    void MoveBackground(RectTransform background, Vector2 originalPosition)
    {
        Vector2 newPosition = background.anchoredPosition + new Vector2(-speed, 0) * Time.deltaTime;
        background.anchoredPosition = newPosition;

        // If the background has moved off-screen, reset its position to the right to create a looping effect
        if (background.anchoredPosition.x <= -backgroundWidth)
        {
            background.anchoredPosition = originalPosition;
        }
    }
}
