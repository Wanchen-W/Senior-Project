using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth_V2 : MonoBehaviour
{
    
    public Animator animator;

    public int maxHealth;
    public int enemyType;
    int currentHealth;

    EnemySound enemySound;
    void Start() {

        currentHealth = maxHealth;
        Debug.Log(gameObject.GetComponent<BoxCollider2D>().isTrigger);
        enemySound = GetComponent<EnemySound>();
    }

    public void TakeDamage(int damage) {

        currentHealth -= damage;
        enemySound.playTookDamage();

        if (currentHealth <= 0) {

            Die();

        }
    }

    void Die() {

        Debug.Log("Enemy died");
        enemySound.playDeath();
        animator.SetBool("isDead", true);
        //Debug.Log(GetComponent<BoxCollider2D>().enabled);
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Rigidbody2D>().simulated = false;
        if (enemyType == 1)
            GetComponent<Enemy1AI>().enabled = false;
        else if (enemyType == 2)
            GetComponent<Enemy2AI>().enabled = false;

        Destroy(this.gameObject, 2);

        this.enabled = false;

    }

}
