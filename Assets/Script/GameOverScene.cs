using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public Health playerHealth;
    public VectorValue startingPosition;
    public Vector2 startLevel0 = new Vector2(-5.57f,0.17f);
    public VectorValue startingScale;
    public Vector2 scaleLevel0 = new Vector2(0.2f,0.2f);
    public void RestartButton()
    {
        SceneManager.LoadScene("Beginning-Scene");
        playerHealth.healthInitial = 3;
        playerHealth.lifeInital = 3;
        startingPosition.initialValue = startLevel0;
        startingScale.initialValue = scaleLevel0;
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("UI-Starting");
    }
}
