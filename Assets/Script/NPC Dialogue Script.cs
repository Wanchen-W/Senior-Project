using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;


public class NPCDialogueScript : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;
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
    public void openDialogues(Messages[] messages, Actors[] actors)
    {
        isActive = true;
        currentMessage = messages;
        currentActors = actors;
    }
    void Update()
    {
        if (isActive && currentActors[currentMessage[index].ActorID].name == "John")
        {
            
            if(currentActors[currentMessage[index].ActorID].description == "Angry") {

                angry_speaking = true;
            }
            else
            {
                speaking = true;
            }
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
                FindObjectOfType<DiaologueManager>().findDialogue();
                dialoguePannel.SetActive(true);
                StartCoroutine(Typing());
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
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
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
            Debug.Log("0");
            playerClose = false;
            zeroText();
        }
    }

    public void zeroText()
    {
        dialoguePannel.SetActive(false);
        index = 0;
        dialogueText.text = "";
    }
}
