using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    private Rigidbody2D playerRB;
    private Animator playerAnim;

    [SerializeField]
    private float playerSpeed;

    public float jumpForce;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    // Double Jumped:
    //private bool doubleJumped;

    private bool grounded;
	// Use this for initialization
	void Start () {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update () {
        //Double Jumped
        //if (grounded) doubleJumped = false;

        PlayerMovement();
        PlayerJump();
    }

    public void PlayerMovement()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            playerRB.velocity = new Vector2(playerSpeed, playerRB.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") < 0)
        {
            playerRB.velocity = new Vector2(-playerSpeed, playerRB.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        playerAnim.SetFloat("speed", Mathf.Abs(playerRB.velocity.x));
    }

    public void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
        }

        playerAnim.SetFloat("vSpeed", Mathf.Abs(playerRB.velocity.y));

        // Double Jumped
        //if (Input.GetButtonDown("Jump") && !doubleJumped && !grounded)
        //{
        //    playerRB.velocity = new Vector2(playerRB.velocity.x, verticalSpeed);
        //    doubleJumped = true;
        //}
    }

}
