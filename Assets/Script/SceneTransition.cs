using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition:MonoBehaviour
{
   public string sceneToLoad;
   public Vector2 playerPosition;
    public VectorValue storagePosition;
    public Vector2 playerScale;
    public VectorValue storageScale;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            storagePosition.initialValue = playerPosition;
            storageScale.initialValue = playerScale;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
