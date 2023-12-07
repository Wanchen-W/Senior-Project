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
        isPaused = false;
        //Do NOT CHANGE THE VISABILITY OF ALL UI LAYERS
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape pressed. Current State: " + isPaused);
            // Toggle pause state regardless of UI elements for debugging
            if (isPaused)
            {
                Debug.Log("Resuming Game");
                ResumeGame();
            }
            else
            {
                Debug.Log("Pausing Game");
                PauseGame();
            }
        }
    }

    public void ToggleSettingsWindow()
    {
        settingsWindow.SetActive(!settingsWindow.activeSelf);
        CheckGamePauseState();

    }

    public void ToggleSettingsMenuCanvas()
    {
        settingsMenuCanvas.SetActive(!settingsMenuCanvas.activeSelf);
        CheckGamePauseState();

    }

    public void PauseGame()
    {
      
        if (!isPaused)
        {
            Debug.Log("Pausing game");
            SetPauseCanvasesActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void ResumeGame()
    {

       
            Debug.Log("Resuming game");
            SetPauseCanvasesActive(false);
            settingsWindow.SetActive(false);
            settingsMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        

    }

    public void QuitToStartMenu()
    {
        // Load the "UI-Starting" scene
        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene("UI-Starting");
    }

    public void SetPauseCanvasesActive(bool isActive)
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

    private bool IsAnyUIActive()
    {
        // Check if any UI element (pause canvases, settings menu, settings window) is active
        return IsAnyPauseCanvasActive() || settingsMenuCanvas.activeSelf || settingsWindow.activeSelf;
    }

    private void CheckGamePauseState()
    {
        // Adjusted logic to handle the first toggle correctly
        if (IsAnyUIActive() && !isPaused)
        {
            PauseGame();
        }
        else if (!IsAnyUIActive() && isPaused)
        {
            ResumeGame();
        }
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }

    public void CloseSettingsWindow()
    {
        settingsWindow.SetActive(false);

    }

}
