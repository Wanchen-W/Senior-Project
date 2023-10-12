using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonClickFeedback : MonoBehaviour, IPointerClickHandler
{
    public Color defaultColor = Color.white;
    public Color clickColor = Color.gray;
    private Button button;

    void Start()
    {
        // Get the Button component on this GameObject
        button = GetComponent<Button>();

        // Set the default color
        SetButtonColor(defaultColor);
    }

    // This method is called when the button is clicked
    public void OnPointerClick(PointerEventData eventData)
    {
        // Change the button color to indicate it has been clicked
        SetButtonColor(clickColor);

        // Optionally, reset the color after a short delay
        Invoke("ResetColor", 0.1f);
    }

    // Change the color of the button to the given color
    private void SetButtonColor(Color color)
    {
        var colorBlock = button.colors;
        colorBlock.normalColor = color;
        button.colors = colorBlock;
    }

    // Reset the color of the button to the default color
    private void ResetColor()
    {
        SetButtonColor(defaultColor);
    }
}
