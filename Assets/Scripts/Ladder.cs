using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    public GameObject playerOBJ;
    private Rigidbody2D playerRB;
    private Animator playerAnim;
    bool canClimb = false;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        other.GetComponent<Rigidbody2D>().gravityScale = 0f;
        Animator animationObj = playerOBJ.GetComponentInChildren<Animator>();
        if (other.tag == "Player" && Input.GetAxis("Vertical") > 0)
        {
            other.GetComponent<Rigidbody2D>().transform.Translate(0, 1 * Time.deltaTime, 0);
            //other.GetComponent<Rigidbody2D>().gravityScale = 0f;
            animationObj.speed = 1;
            animationObj.Play("claw_climbing");

        }
        else if (other.tag == "Player" && Input.GetAxis("Vertical") < 0)
        {
            other.GetComponent<Rigidbody2D>().transform.Translate(0, -1 * Time.deltaTime, 0);
            //other.GetComponent<Rigidbody2D>().gravityScale = 0f;
            animationObj.speed = 1;
            animationObj.Play("claw_climbing");
        }
        else if (grounded)
        {
            animationObj.speed = 1;
            animationObj.Play("claw_idle");
            //animationObj.speed = 0; //pause animation
            other.GetComponent<Rigidbody2D>().gravityScale = 2.8f;
            playerOBJ.GetComponent<Rigidbody2D>().gravityScale = 2.8f;
        }
        else {
            animationObj.speed = 0;
        }
    }

   /* private void OnTriggerExit(Collider other)
    {
        Animator animationObj = playerOBJ.GetComponentInChildren<Animator>();
        animationObj.Play("claw_idle");
        //animationObj.speed = 0; //pause animation
        other.GetComponent<Rigidbody2D>().gravityScale = 2.8f;
        playerOBJ.GetComponent<Rigidbody2D>().gravityScale = 2.8f;

    }*/

    void OnTriggerExit2D(Collider2D other)
    {
        Animator animationObj = playerOBJ.GetComponentInChildren<Animator>();
        animationObj.speed = 1;
        animationObj.Play("claw_idle");
        //animationObj.speed = 0; //pause animation
        other.GetComponent<Rigidbody2D>().gravityScale = 2.8f;
        playerOBJ.GetComponent<Rigidbody2D>().gravityScale = 2.8f;
        //other = null;
    }

    /*void OnTriggerEnter(Collider2D other)
    {
        if (!grounded)
        {
            other.GetComponent<Rigidbody2D>().gravityScale = 0f;
        }
    }*/
}