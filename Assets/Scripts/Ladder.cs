using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    GameObject playerOBJ;
    public float speed = 6f;
    private Rigidbody2D playerRB;
    private Animator playerAnim;
    bool canClimb = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetAxis("Vertical") > 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
            playerRB.gravityScale = 0f;
            playerRB.mass = 0f;
        }
        else if (other.tag == "Player" && Input.GetAxis("Vertical") < 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
            playerRB.mass = 0f;
            playerRB.gravityScale = 0f;
        }
        else {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1);
        }
    }
}