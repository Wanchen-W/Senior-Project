using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Assign your panel (pause menu UI) here in inspector.
    private bool isPaused = false;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); // Deactivate the pause menu UI.
        Time.timeScale = 1f; // Resume the game.
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); // Activate the pause menu UI.
        Time.timeScale = 0f; // Freeze the game.
        isPaused = true;
    }
}
