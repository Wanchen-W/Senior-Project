using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogueScript : MonoBehaviour
{
    public string[] dialogues;
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePannel;
    private int index;
    public float textSpeed;
    public bool playerClose;
   // public GameObject button1;
  
    // Update is called once per frame
    void Update()
    {
     if(Input.GetMouseButtonDown(1) &&playerClose) {
            if (dialoguePannel.activeInHierarchy) { 
                zeroText();
            }
            else { 
                dialoguePannel.SetActive(true);
                StartCoroutine(Typing());
            }
        }   
    }

    IEnumerator Typing() {
        foreach (char item in dialogues[index].ToCharArray())
        {
            dialogueText.text += item;
            yield return new WaitForSeconds(textSpeed); 
        }
    }

    public void nextLine()
    {
        if(index< (dialogues.Length-1)) {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player") {
            playerClose = true;
            Debug.Log("npc");
            Debug.Log(transform.position.x);
            Debug.Log("Player");
            Debug.Log(collision.transform.position.x);
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
