using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth_V2 : MonoBehaviour
{
    
    public Animator animator;

    public int maxHealth;
    int currentHealth;

    void Start() {

        currentHealth = maxHealth;
        Debug.Log(gameObject.GetComponent<BoxCollider2D>().isTrigger);
    }

    public void TakeDamage(int damage) {

        currentHealth -= damage;

        if (currentHealth <= 0) {

            Die();

        }
    }

    void Die() {

        Debug.Log("Enemy died");

        animator.SetBool("isDead", true);
        Debug.Log(GetComponent<BoxCollider2D>().enabled);
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Rigidbody2D>().simulated = false;
        GetComponent<Enemy1AI>().enabled = false;

        StartCoroutine(Delay(5f));
        
        //Destroy(this.gameObject);

        this.enabled = false;

    }

    IEnumerator Delay(float time) {

        yield return new WaitForSeconds(time);

    }
}
