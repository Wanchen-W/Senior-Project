using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerAttack_V2 : MonoBehaviour
{
    [SerializeField] private HitEffect hiteffect; 

    public Transform handTransform; 
    public Transform attackCenter;
    public float attackHitbox = 0.5f;
    public LayerMask enemyLayer;
    public int attackDamage = 25;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;
    private int attackCount = 0; // To keep track of the attack combo count

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        if(handTransform != null)
        {
            attackCenter.transform.position = handTransform.position;
            attackCenter.transform.rotation = handTransform.rotation;
            Debug.DrawLine(transform.position, handTransform.position, Color.red);

        }
    }



    void Attack()
    {
        Collider2D[] enemiesInRange = Physics2D.OverlapCircleAll(attackCenter.position, attackHitbox, enemyLayer);

        foreach (Collider2D enemy in enemiesInRange)
        {
            Debug.Log("Enemy hit");
            enemy.GetComponent<EnemyHealth_V2>().TakeDamage(attackDamage);
            
            if (hiteffect != null)
            {
                hiteffect.ShowHitEffect(enemy.transform.position);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackCenter == null)
            return;

        Gizmos.DrawWireSphere(attackCenter.position, attackHitbox);
    }
}
