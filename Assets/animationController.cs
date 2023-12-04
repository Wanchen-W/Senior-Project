using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class animationController : MonoBehaviour
{
    public Text respawnMessage;
    public Health health;
    // Start is called before the first frame update
    private Animator propAnimation;
    private string life;
    void Start()
    {
        propAnimation = GetComponent<Animator>();
        GetComponent<Animator>().SetBool("entered", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            life =  health.lifeInital.ToString();
            respawnMessage.text = "You reached a respawn point! You have " + life + " life.";
            respawnMessage.color = Color.white;
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
