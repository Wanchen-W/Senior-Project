using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private Animator npcAnimation;
    // Start is called before the first frame update
    void Start()
    {
        npcAnimation = GetComponent<Animator>();
        GetComponent<Animator>().SetBool("speaking", false);
        GetComponent<Animator>().SetBool("angry_speaking", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (NPCDialogueScript.isActive)
        {
            if(NPCDialogueScript.speaking)
            {
                GetComponent<Animator>().SetBool("speaking", true);
            }
           else if(NPCDialogueScript.angry_speaking)
            {
                GetComponent<Animator>().SetBool("angry_speaking", true);
            }
            else {
                GetComponent<Animator>().SetBool("speaking", false);
                GetComponent<Animator>().SetBool("angry_speaking", false);
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("speaking", false);
            GetComponent<Animator>().SetBool("angry_speaking", false);
        }
    }
}
