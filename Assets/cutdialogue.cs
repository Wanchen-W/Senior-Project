using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class cutdialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePannel;
    private int index;
    private int charIndex;
    private int charLength;
    public float textSpeed;
    public Image currentImage;
    public TextMeshProUGUI nameText;
    public Sprite currentSprite;
    public string[] currentText;
    public string currentName;
    private void Start()
    {
        charLength = currentText.Length - 1;
        dialoguePannel.SetActive(true);
        StartCoroutine(Typing());
    }
    void Update()
    {
     
       

    }


    IEnumerator Typing()
    {
        foreach (char item in currentText[index].ToCharArray())
        {
            dialogueText.text += item;
            currentImage.sprite = currentSprite;
            nameText.text = currentText[index];
            charIndex++;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void zeroText()
    {
        dialoguePannel.SetActive(false);
        index = 0;
        dialogueText.text = "";
    }

    public void nextLine() {
        if (index < (currentText.Length - 1))
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }
}
