using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class cutdialogue : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePannel;
    private int index=0;
    private int charIndex;
    private int charLength;
    public float textSpeed;
    public Image currentImage;
    public TextMeshProUGUI nameText;
    public Sprite currentSprite;
    public TextMeshProUGUI currentName;
    Messages[] currentMessage;
    Actors[] currentActors;
    public void openDialogues(Messages[] messages, Actors[] actors)
    {
        currentMessage = messages;
        currentActors = actors;
    }
    private void Start()
    {
        FindObjectOfType<DiaologueManager>().findDialogue2();
        charLength = currentMessage[index].message.Length - 1;
        dialoguePannel.SetActive(true);
        StartCoroutine(Typing());
        Debug.Log(currentMessage.Length);
    }
    void Update()
    {
     
       

    }


    IEnumerator Typing()
    {
        foreach (char item in currentMessage[index].message.ToCharArray())
        {
            dialogueText.text += item;
            currentImage.sprite = currentActors[currentMessage[index].ActorID].sprite;
            currentName.text = currentActors[currentMessage[index].ActorID].name;
            charIndex++;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    public void zeroText()
    {
       
        index = 0;
        dialogueText.text = "";
        dialoguePannel.SetActive(false);
       
    }

    public void nextLine() {
        if (index < (currentMessage[index].message.Length - 1))
        {
            index++;
            dialogueText.text = "";
            Debug.Log("yes");
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }
}
