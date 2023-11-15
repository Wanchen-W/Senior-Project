using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Beginning-Scene");
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("UI-Starting");
    }
}
