using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Health : MonoBehaviour {

    private GameObject respawn;
    public static int healthNumber;
    public static int lifeLeft;
    public static bool isDead;
    public Health currentHealth;
    public GameObject health3;
    public GameObject health2;
    public GameObject health1;

    void Start()
    {
        respawn = GameObject.FindGameObjectWithTag("Respawn");
        healthNumber = currentHealth.healthInitial;
        lifeLeft = currentHealth.lifeInital;
        isDead = false;
    }

    void Update()
    {
        currentHealth.healthInitial = healthNumber;
        currentHealth.lifeInital = lifeLeft;
        if (healthNumber == 3) {
            health3.SetActive(true);
            health2.SetActive(true);
            health1.SetActive(true);
        }
        else if (healthNumber == 2) {
            health3.SetActive(false);
            health2.SetActive(true);
            health1.SetActive(true);
        }
        else if(healthNumber == 1)
        {
            health3.SetActive(false);
            health2.SetActive(false);
            health1.SetActive(true);
        }
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
        healthNumber = healthNumber - 1;
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
        healthNumber = healthNumber + 1;

        if (!health2.activeInHierarchy) {

            health2.SetActive(true);

        }

        else if (!health3.activeInHierarchy) {
            
            health3.SetActive(true);

        }
        
    }

    public void Respawn() {
        lifeLeft--;
        if (lifeLeft == 0)
        {
            Debug.Log("dead");
            isDead = true;
            return;
        }
        else
        {
            gameObject.transform.position = respawn.transform.position;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        health3.SetActive(true);
        health2.SetActive(true);
        health1.SetActive(true);
        healthNumber = 3;
    }
}
