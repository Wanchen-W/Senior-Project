using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{
    public Image fadeImage;
    public Slider progressBar; 
    public Text loadingText;
    public Text continueText; 

    private bool loadCompleted = false;

    private void Start()
    {
        fadeImage.gameObject.SetActive(true); 
        continueText.gameObject.SetActive(false); 
        StartCoroutine(FadeInAndLoad());
    }

    private IEnumerator FadeInAndLoad()
    {
        // Fade in
        for (float t = 1f; t >= 0; t -= Time.deltaTime)
        {
            fadeImage.color = new Color(0, 0, 0, t);
            yield return null;
        }
        fadeImage.gameObject.SetActive(false);

        // Simulate loading for 2 seconds
        for (float t = 0; t <= 2; t += Time.deltaTime)
        {
            progressBar.value = t / 2f;
            yield return null;
        }

        progressBar.gameObject.SetActive(false); // Hide the slider after loading
        loadingText.gameObject.SetActive(false);
        continueText.gameObject.SetActive(true);
        loadCompleted = true;

        StartCoroutine(BlinkContinueText());
    }

    private IEnumerator BlinkContinueText()
    {
        while (true) // Keeps blinking indefinitely until interrupted
        {
            continueText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);

            continueText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void Update()
    {
        if (loadCompleted && Input.anyKey)
        {
            SceneManager.LoadScene("UI-Starting");     //jump to main menu
        }
    }
}
