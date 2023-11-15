using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    public void LoadMenuScene()
    {
        // Pause time scale in case it's set to 0 from the paused state.
        Time.timeScale = 1f;

        // Load the menu scene.
        // Replace "MenuSceneName" with the name of your menu scene.
        SceneManager.LoadScene("UI-pause");
    }
}
