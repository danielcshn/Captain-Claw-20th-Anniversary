using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    public float speed = 6f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player" && Input.GetAxis("Vertical") > 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, speed);
        }

        if (other.tag == "Player" && Input.GetAxis("Vertical") < 0)
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -speed);
        }
    }
}