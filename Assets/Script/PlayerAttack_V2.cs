using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack_V2 : MonoBehaviour {
    
    public Transform attackCenter;
    public float attackHitbox = 0.5f;
    public LayerMask enemyLayer;

    public int attackDamage = 25;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update() {
        
        if (Time.time >= nextAttackTime) {

            if (Input.GetMouseButtonDown(0)) {

                Attack();
                nextAttackTime = Time.time + 1f / attackRate;

            }

        }
        
    }

    void Attack() {

        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackCenter.position, attackHitbox, enemyLayer);

        foreach(Collider2D enemy in enemiesInRange) {

            Debug.Log("Enemy hit");
            enemy.GetComponent<EnemyHealth_V2>().TakeDamage(attackDamage);

        }
    }

    void OnDrawGizmosSelected() {

        if (attackCenter == null)
            return;

        Gizmos.DrawWireSphere(attackCenter.position, attackHitbox);
    }
}
