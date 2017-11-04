using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePoint : MonoBehaviour {

    private Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (anim.GetFloat("check") == 0)
            {
                anim.SetFloat("check", 1);

                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
            }
        }
    }
}
