using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 10f;
    private float directionX = 0f;
    private float directionY = 0f;
    private Rigidbody2D player;
    private Animator playerAnimation;
    Vector2 movement;
    private Vector2 right = new Vector2(0.2f,0.2f);
    private Vector2 left = new Vector2(-0.2f,0.2f);

    public float distanceFromGround = 3.0f;

    public LayerMask GroundLayer;

    // Start is called before the first frame update
    void Start()
    {
     player = GetComponent<Rigidbody2D>();   
     playerAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        directionX = Input.GetAxis("Horizontal");
        directionY = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && isOnGround()) {

            Jump();

        }

        if (directionX > 0f )
        {
            player.velocity = new Vector2 ( directionX * speed, player.velocity.y);
            transform.localScale = right;
        }
        else if (directionX < 0f )
        {
            player.velocity = new Vector2(directionX * speed, player.velocity.y);
            transform.localScale = left;
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        playerAnimation.SetFloat("Speed",Mathf.Abs(player.velocity.x));
    }

    void Jump() {

        player.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

    }

    public bool isOnGround() {

        RaycastHit2D check = Physics2D.Raycast(transform.position, Vector2.down, distanceFromGround, GroundLayer);

        if (check.collider != null) {

            return true;

        }

        return false;

    }

    private void FixedUpdate()
    {

    }
}
