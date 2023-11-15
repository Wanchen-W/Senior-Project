using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject gameOptionsCanvas;
    public GameObject levelSelectionCanvas;
    public GameObject settingsCanvas;
    private Animator settingsAnimator;

    private GameObject currentCanvas; 

    void Start()
    {
        settingsAnimator = settingsCanvas.GetComponent<Animator>();
    }

    void Update()
    {
        // Handle the Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsCanvas.activeSelf)
            {
                SetActiveCanvas(mainMenuCanvas); // Return to main menu from settings
            }
            else if (levelSelectionCanvas.activeSelf)

            {
                Debug.Log("Trying to go back to game options canvas");
                SetActiveCanvas(gameOptionsCanvas); // Return to game options from level selection
            }
            else if (gameOptionsCanvas.activeSelf)
            {
                SetActiveCanvas(mainMenuCanvas); // Return to main menu from game options
            }
        }
    }

    public void OnStartGameClicked()
    {
        SetActiveCanvas(gameOptionsCanvas);
    }

    public void OnSelectLevelClicked()
    {
        SetActiveCanvas(levelSelectionCanvas);
    }

    public void LoadGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ToggleSettings()
    {
        bool isSettingsActive = settingsCanvas.activeSelf;

        if (!isSettingsActive)
        {
            SetActiveCanvas(settingsCanvas);
            // Play the unfolding animation when the settings panel is being activated
            settingsAnimator.SetTrigger("unfold");
        }
        else
        {
            SetActiveCanvas(mainMenuCanvas);
        }
    }

    private void SetActiveCanvas(GameObject canvasToActivate)
    {
        mainMenuCanvas.SetActive(false);
        gameOptionsCanvas.SetActive(false);
        levelSelectionCanvas.SetActive(false);
        settingsCanvas.SetActive(false);
        canvasToActivate.SetActive(true);
        currentCanvas = canvasToActivate; 
    }
}
