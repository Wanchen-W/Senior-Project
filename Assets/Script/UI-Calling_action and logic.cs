using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenuCanvas;          
    public GameObject gameOptionsCanvas;       
    public GameObject levelSelectionCanvas;   

    private void Start()
    {
       
        mainMenuCanvas.SetActive(true);
        gameOptionsCanvas.SetActive(false);
        levelSelectionCanvas.SetActive(false);
    }

    public void OnStartGameClicked()
    {
        
        mainMenuCanvas.SetActive(false);
        gameOptionsCanvas.SetActive(true);
    }

    public void OnSelectLevelClicked()
    {
      
        gameOptionsCanvas.SetActive(false);
        levelSelectionCanvas.SetActive(true);
    }

    public void LoadGameScene(string sceneName)
    {
       
        SceneManager.LoadScene(sceneName);
    }
}
