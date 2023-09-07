using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private float direction = 0f;
    private Rigidbody2D player;
    private Animator playerAnimation;
    Vector2 movement;
    private Vector2 right = new Vector2(0.2f,0.2f);
    private Vector2 left = new Vector2(-0.2f,0.2f);
    // Start is called before the first frame update
    void Start()
    {
     player = GetComponent<Rigidbody2D>();   
     playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        if (direction > 0f )
        {
            player.velocity = new Vector2 ( direction * speed, player.velocity.y);
            transform.localScale = right;
        }
        else if (direction < 0f )
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = left;
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        playerAnimation.SetFloat("Speed",Mathf.Abs(player.velocity.x));
    }

    private void FixedUpdate()
    {
        
    }
}
