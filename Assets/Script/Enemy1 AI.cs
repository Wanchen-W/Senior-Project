using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy1AI : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D enemy;
    private Animator enemyAnimation;
    public float speed=5f;
    private Vector2 right = new Vector2(0.25f, 0.25f);
    private Vector2 left = new Vector2(-0.25f, 0.25f);
    public float distanceBetween;
    public float minimunDistance;
    private float distance;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        enemyAnimation = GetComponent<Animator>();
        GetComponent<Animator>().SetBool("isRunning", false);
        GetComponent<Animator>().SetBool("isAttacking", false);
    }

    // Update is called once per frame
    void Update()
    {   
        direction = player.transform.position - enemy.transform.position;
        distance = Vector2.Distance(enemy.transform.position, player.transform.position);
        GetComponent<Animator>().SetBool("isRunning", false);
        GetComponent<Animator>().SetBool("isAttacking", false);
        if (distance < distanceBetween && distance>minimunDistance) {
            if(direction.x < 0f)
            {
                transform.localScale = right;
            }
            else
            {
                transform.localScale = left;
            }
            GetComponent<Animator>().SetBool("isRunning", true);
            enemy.transform.position = Vector2.MoveTowards(enemy.transform.position,player.transform.position,speed*Time.deltaTime);
        }
        else if (distance < minimunDistance) {
            GetComponent<Animator>().SetBool("isAttacking", true);
            //start to attack
        }
    }
}
