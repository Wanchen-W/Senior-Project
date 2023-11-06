using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenuToggle : MonoBehaviour
{
    public GameObject[] pauseCanvases;   // Store references to all pause canvases here.
    public GameObject settingsWindow;    // Reference to your specific settings window.
    public GameObject settingsMenuCanvas;

    private bool isPaused = false;

    void Start()
    {
        SetPauseCanvasesActive(false);
        settingsWindow.SetActive(false); 
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (settingsWindow.activeSelf)
            {
                ToggleSettingsWindow();
                return;
            }

            if (settingsMenuCanvas.activeSelf && !settingsWindow.activeSelf)
            {
                ResumeGame();
                return;
            }

            if (IsOnlyPauseCanvasActive())
            {
                ResumeGame();
                return;
            }

            if (!IsAnyPauseCanvasActive() && !settingsWindow.activeSelf && !settingsMenuCanvas.activeSelf)
            {
                PauseGame();
                return;
            }
        }
    }

    public void ToggleSettingsWindow()
    {
        settingsWindow.SetActive(!settingsWindow.activeSelf);
    }

    public void ToggleSettingsMenuCanvas()
    {
        settingsMenuCanvas.SetActive(!settingsMenuCanvas.activeSelf);

        
        if (settingsMenuCanvas.activeSelf)
        {
            PauseGame();
        }
        else if (IsOnlyPauseCanvasActive())
        {
            ResumeGame();
        }
    }

    public void PauseGame()
    {
        SetPauseCanvasesActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        SetPauseCanvasesActive(false);
        settingsWindow.SetActive(false); // Ensure settings window is also deactivated
        settingsMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitToStartMenu()
    {
        // Load the "UI-Starting" scene
        SceneManager.LoadScene("UI-Starting");
    }

    private void SetPauseCanvasesActive(bool isActive)
    {
        foreach (GameObject canvas in pauseCanvases)
        {
            canvas.SetActive(isActive);
        }
    }

    // Check if any pause canvas is currently active
    private bool IsAnyPauseCanvasActive()
    {
        foreach (GameObject canvas in pauseCanvases)
        {
            if (canvas.activeSelf)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsOnlyPauseCanvasActive()
    {
        // This checks if the only active canvas is a pause canvas and not settings or menu
        return IsAnyPauseCanvasActive() && !settingsWindow.activeSelf && !settingsMenuCanvas.activeSelf;
    }
}
