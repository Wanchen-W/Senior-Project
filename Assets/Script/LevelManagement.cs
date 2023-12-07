using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagement : MonoBehaviour
{
    public VectorValue position;
    public VectorValue scale;
    public Health health;
    // Start is called before the first frame update
    
    public void beginningLevel()
    {
        change();
        SceneManager.LoadScene("Beginning-Scene");
        position.initialValue = new Vector2(-5.57f,0.17f);
    }
    public void Level() {
        change();
        SceneManager.LoadScene("Level 2");
        position.initialValue = new Vector2(-4.83f,-1.207f);
    }

    public void Level1()
    {
        change();
        SceneManager.LoadScene("Level 1");
        position.initialValue = new Vector2(-5.46f, -1.3f);
    }
    public void credit()
    {
        Debug.Log("s");
        change();
        SceneManager.LoadScene("Credit");
        position.initialValue = new Vector2(-5.57f, 0.17f);
    }
    public void LevelNpc()
    {
        change();
        SceneManager.LoadScene("NPC Event");
        position.initialValue = new Vector2(-6.78f, -1.35f);
    }
    void change() { 
        health.healthInitial = 3;
        health.lifeInital = 3;
        scale.initialValue = new Vector2(0.2f, 0.2f);
    }
}
