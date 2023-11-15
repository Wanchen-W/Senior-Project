using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Rigidbody2D enemy;
    private Animator enemyAnimation;
    private Vector2 right = new Vector2(-0.1f, 0.1f);
    private Vector2 left = new Vector2(0.1f, 0.1f);
    public float distanceBetween;
    public float minimunDistance;
    private float distance;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        enemyAnimation = GetComponent<Animator>();
        GetComponent<Animator>().SetBool("isAttacking", false);
    }

    // Update is called once per frame
    void Update()
    {
        direction = player.transform.position - enemy.transform.position;
        distance = Vector2.Distance(enemy.transform.position, player.transform.position);
        GetComponent<Animator>().SetBool("isAttacking", false);
        if (distance < distanceBetween && distance > minimunDistance)
        {
            if (direction.x < 0f)
            {
                transform.localScale = right;
            }
            else
            {
                transform.localScale = left;
            }
        }
        else if (distance < minimunDistance)
        {
            GetComponent<Animator>().SetBool("isAttacking", true);
        }
    }
}
