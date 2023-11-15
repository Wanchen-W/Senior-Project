using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class DiaologueManager : MonoBehaviour
{
    public Messages[] messages;
    public Actors[] actor;
    public void findDialogue()
    {
        FindObjectOfType<NPCDialogueScript>().openDialogues(messages,actor);
    }
    public void findDialogue2()
    {
        FindObjectOfType<cutdialogue>().openDialogues(messages, actor);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
public class Messages {
    public int ActorID;
    public string message;
}
[System.Serializable]
public class Actors
{
    public string name;
    public string description;
    public Sprite sprite;
}