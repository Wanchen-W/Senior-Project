using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance; // Singleton instance

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ToggleMute()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
        Debug.Log("Audio Toggled. Current Volume: " + AudioListener.volume);
    }
}