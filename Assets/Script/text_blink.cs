using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic; // Required for Lists

public class BlinkTextEffect : MonoBehaviour
{
    public List<Text> textsToBlink; 
    public float blinkInterval = 0.5f;

    private void Start()
    {
        foreach (var text in textsToBlink)
        {
            StartCoroutine(BlinkText(text));
        }
    }

    private IEnumerator BlinkText(Text text)
    {
        while (true)
        {
            text.gameObject.SetActive(false);
            yield return new WaitForSeconds(blinkInterval);

            text.gameObject.SetActive(true);
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}
