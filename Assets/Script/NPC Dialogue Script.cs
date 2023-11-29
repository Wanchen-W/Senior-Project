using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class NPCDialogueScript : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;
    public GameObject mark;
    public GameObject dialoguePannel;
    private int index;
    public float textSpeed;
    public bool playerClose;
    public Image currentImage;
    public TextMeshProUGUI currentName;
    public static bool isActive = false;
    public static bool speaking = false;
    public static bool angry_speaking = false;
    Messages[] currentMessage;
    Actors[] currentActors;
    public int divergeIndex;
    public int[] choiceIndexes;
    private Coroutine typingCoroutine;
    public Button continueButton;
    public Button choice1;
    public Button choice2;
    public Button choice3;
    public void openDialogues(Messages[] messages, Actors[] actors)
    {
        isActive = true;
        currentMessage = messages;
        currentActors = actors;
    }
    void Update()
    {
        check();
        if (isActive && currentActors[currentMessage[index].ActorID].name == "John")
        {
            speaking = true;
        }
        else if(isActive && currentActors[currentMessage[index].ActorID].name != "John")
        {
            speaking = false;
            angry_speaking = false;
        }
        else
        {
            speaking = false;
            angry_speaking = false;
        }
     if(Input.GetMouseButtonDown(1) &&playerClose) {
            if (dialoguePannel.activeInHierarchy) { 
                zeroText();
            }
            else {
                zeroText();
                FindObjectOfType<DiaologueManager>().findDialogue();
                dialoguePannel.SetActive(true);
                typingCoroutine = StartCoroutine(Typing());
            }
        }   
    }

   
    IEnumerator Typing() {
        foreach (char item in currentMessage[index].message.ToCharArray())
        {
            
            dialogueText.text += item;
            currentImage.sprite = currentActors[currentMessage[index].ActorID].sprite;
            currentName.text = currentActors[currentMessage[index].ActorID].name;
            yield return new WaitForSeconds(textSpeed); 
        }
    }

    public void nextLine()
    {
        if(index< (currentMessage.Length-1)) {
            if (index == choiceIndexes[1] || index == choiceIndexes[3])
            {
                index = divergeIndex;
            }
            else
            {
                index++;
            }
            dialogueText.text = "";
            StopCoroutine(typingCoroutine);
            typingCoroutine = StartCoroutine(Typing());
         
        }
        else
        {
            isActive = false;
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            mark.SetActive(true);
            playerClose = true;
            if ((this.transform.position.x - collision.transform.position.x)>0) {
                
                this.transform.localScale = new Vector2(-0.13f, 0.13f);
            }
            else
            {
                this.transform.localScale = new Vector2(0.13f, 0.13f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerClose = false;
            zeroText();
            mark.SetActive(false);
        }
    }

    public void check()
    {
        if(index == divergeIndex)
        {
            continueButton.gameObject.SetActive(false);
            choice1.gameObject.SetActive(true);
            choice2.gameObject.SetActive(true);
            choice3.gameObject.SetActive(true);
        }
        else
        {
            continueButton.gameObject.SetActive(true);
            choice1.gameObject.SetActive(false);
            choice2.gameObject.SetActive(false);
            choice3.gameObject.SetActive(false);
        }
    }
    public void choice1Start() 
    {
        dialogueText.text = "";
        index = choiceIndexes[0];
        typingCoroutine = StartCoroutine(Typing());
    }
    public void choice2Start()
    {
        dialogueText.text = "";
        index = choiceIndexes[2];
        typingCoroutine = StartCoroutine(Typing());
    }
    public void choice3Start()
    {
        dialogueText.text = "";
        index = choiceIndexes[4];
        typingCoroutine = StartCoroutine(Typing());
    }
    public void zeroText()
    {
        dialoguePannel.SetActive(false);
        index = 0;
        dialogueText.text = "";
    }
}
