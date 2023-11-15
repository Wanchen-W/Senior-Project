using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class animationController : MonoBehaviour
{
    public TextMeshProUGUI respawnMessage;
    // Start is called before the first frame update
    private Animator propAnimation;
    void Start()
    {
        propAnimation = GetComponent<Animator>();
        GetComponent<Animator>().SetBool("entered", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            respawnMessage.gameObject.SetActive(true);
            GetComponent<Animator>().SetBool("entered", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!Player_Health.isDead) { 
            if (collision.tag == "Player")
            {
                respawnMessage.gameObject.SetActive(false);
                GetComponent<Animator>().SetBool("entered", false);
            }
        }
    }
}
