using System.Collections;
using System.Collections.Generic;
using UnityEditor;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpPower = 10f;
    private float directionX = 0f;
    private float directionY = 0f;
    private float speedCopy = 0f;
    private Rigidbody2D player;
    private Animator playerAnimation;
    public VectorValue startingPosition;
    public VectorValue startingScale;
    private Vector2 right = new Vector2(0.2f,0.2f);
    private Vector2 left = new Vector2(-0.2f,0.2f);
    private Vector2 respawnPoint;

    public float distanceFromGround = 2.0f;

    public LayerMask GroundLayer;

    bool jumping;
    bool holdingJump;
    float counterJump = -5f;

    // the following variables are for continuous attact actions: 
    public float attackRate = 1f; // The rate at which the attack can be initiated
    private float nextAttackTime = 0f; 
    private int attackCount = 0; // To keep track of the attack count

    //Variables for dash mechanic
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
    private float dashEnergyConsumption = 70f;

    [SerializeField] private TrailRenderer tr;

    public float maxEnergy = 100f;
    private float currentEnergy;
    public Slider energyBar;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
        GetComponent<Animator>().SetBool("onGroundCheck", true);
        GetComponent<Animator>().SetBool("attack1", false);
        speedCopy = speed;
        transform.position = startingPosition.initialValue;
        transform.localScale = startingScale.initialValue;
        respawnPoint = transform.position;

        currentEnergy = maxEnergy;
        energyBar.maxValue = maxEnergy;
        energyBar.value = currentEnergy;

        playerAnimation = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (isDashing)
            return;

        if (NPCDialogueScript.isActive)
        {
            GetComponent<Animator>().SetBool("isIdle", true);
            return;
        }
        if(Player_Health.isDead)
        {
            GetComponent<Animator>().SetBool("gameOver", true);
            return;
        }
        else
        {
            GetComponent<Animator>().SetBool("gameOver", false);
        }
        directionX = Input.GetAxis("Horizontal");
        directionY = Input.GetAxis("Vertical");
        GetComponent<Animator>().SetBool("onGroundCheck", true);
        GetComponent<Animator>().SetBool("isIdle", false);
        GetComponent<Animator>().SetBool("attack1", false);

        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }

        // Reset attack count if enough time has passed since the last attack
        if (Time.time > nextAttackTime)
        {
            attackCount = 0;
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && player.velocity.x != 0 && dashEnergyConsumption <= currentEnergy)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetButtonDown("Jump")) {
            
            holdingJump = true;

            if (isOnGround()) {
               GetComponent<Animator>().SetBool("onGroundCheck", false);
                jumping = true;
                Jump();

            }
            respawnPoint = transform.position;
        }
        else if (Input.GetButtonUp("Jump")) {

            holdingJump = false;
        }
        if (!isOnGround())
        {
            GetComponent<Animator>().SetBool("onGroundCheck", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Animator>().SetBool("attack1", true);
	    }
        if (directionX > 0f && !isDashing)
        {
            StartWalking();
            player.velocity = new Vector2 ( directionX * speed, player.velocity.y);
            transform.localScale = right;
        }
        else if (directionX < 0f && !isDashing)
        {
            StartWalking();
            player.velocity = new Vector2(directionX * speed, player.velocity.y);
            transform.localScale = left;
        }
        else if (!isDashing)
        {
            StartWalking();
            player.velocity = new Vector2(0, player.velocity.y);
        }
        playerAnimation.SetFloat("Jump",player.velocity.y);
        playerAnimation.SetFloat("Speed", Mathf.Abs(player.velocity.x));

        if (currentEnergy < maxEnergy)
            currentEnergy += 0.1f;
        setEnergy(currentEnergy);
    }
    void Attack()
    {
        // Update next attack time
        nextAttackTime = Time.time + 1f / attackRate;
        attackCount = (attackCount + 1) % 3; // 3 attacks in the combo

        if (attackCount >= 2)
        {
            attackCount = 0; // Reset attack sequence if already at the last attack
        }
        else
        {
            attackCount++;

            switch (attackCount)
            {
                case 0:
                    playerAnimation.SetTrigger("attack1");
                    break;
                case 1:
                    playerAnimation.SetTrigger("attack2");
                    break;
                case 2:
                    playerAnimation.SetTrigger("attack3");
                    break;
            }
        }
        if (Time.time > nextAttackTime)
        {
            attackCount = 0;
        }
    }
    public void ResetAttackTrigger()
    {
        playerAnimation.ResetTrigger("attack1");
        playerAnimation.ResetTrigger("attack2");
        playerAnimation.ResetTrigger("attack3");
    }

    void Jump()
    {

            player.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);

    }
    void StartWalking()
    {
        speed = speedCopy;
    }

    void StopWalking()
    {
        speed = 0;
    }

    public bool isOnGround()
    {

        RaycastHit2D check = Physics2D.Raycast(transform.position, Vector2.down, distanceFromGround, GroundLayer);

        if (check.collider != null)
        {

            return true;

        }

        return false;

    }
    public void gameOver()
    {
        Debug.Log("Go to game over");
        SceneManager.LoadScene("Game Oveer");
    }
    private void FixedUpdate() {

        if (isDashing)
            return;

        if (jumping) {

            if (!holdingJump && Vector2.Dot(player.velocity, Vector2.up) > 0) {

                player.AddForce(Vector2.down * -counterJump * player.mass);

            }

        }

    }

    public void setEnergy(float en)
    {
        energyBar.value = en;
    }

    private IEnumerator Dash()
    {

        canDash = false;
        isDashing = true;
        //energy.canRegen = false;
        currentEnergy -= dashEnergyConsumption;
        setEnergy(currentEnergy);
        float orignialGravity = player.gravityScale;
        player.gravityScale = 0f;
        //energy.loseEnergy(dashEnergyConsumption);
        //peHUD.SetEnergy(energy.currentEnergy);
        //Debug.Log("Velocity Pre Dash: " + player.velocity.x);
        player.velocity = new Vector2(directionX * dashingPower, 0f);
        //Debug.Log("Velocity Mid Dash: " + player.velocity.x);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        player.gravityScale = orignialGravity;
        isDashing = false;
        //energy.canRegen = true;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }

}
