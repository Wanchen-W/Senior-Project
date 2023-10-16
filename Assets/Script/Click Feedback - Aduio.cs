using UnityEngine;

public class TextClickFeedback : MonoBehaviour
{
    public AudioClip clickSound;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }
}
