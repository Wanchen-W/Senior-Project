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

        GetComponent<Collider2D>().enabled = false;

        GetComponent<Enemy1AI>().enabled = false;

        StartCoroutine(Delay(5f));
        
        //Destroy(this.gameObject);

        this.enabled = false;

    }

    IEnumerator Delay(float time) {

        yield return new WaitForSeconds(time);

    }
}
