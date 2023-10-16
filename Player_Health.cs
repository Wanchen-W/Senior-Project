using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {

    private GameObject respawn;


    public GameObject health3;
    public GameObject health2;
    public GameObject health1;

    void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn");

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Death")) {

            Respawn();
        }

        else if (collision.CompareTag("Health")) {

            GainHealth();
            Destroy(collision.gameObject);

        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {

       if (collision.collider.CompareTag("Enemy")) {

            LoseHealth();

       }

    }

    private void LoseHealth()
    {

        if (health3.activeInHierarchy) {

            health3.SetActive(false);

        }

        else if (health2.activeInHierarchy) {

            health2.SetActive(false);

        } 

        else {

            health1.SetActive(false);
            Respawn();

        }
        
    }
     
    private void GainHealth() {

        if (!health2.activeInHierarchy) {

            health2.SetActive(true);

        }

        else if (!health3.activeInHierarchy) {
            
            health3.SetActive(true);

        }
        
    }

    public void Respawn() {

        health3.SetActive(true);
        health2.SetActive(true);
        health1.SetActive(true);

        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        gameObject.transform.position = respawn.transform.position;

    }
}
