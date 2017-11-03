using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockDisintegrate : MonoBehaviour {

    private Animator anim;

    public float fadeTime = 1f;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Awake()
    {

    }

    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {

            anim.SetFloat("check", 1);

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();

            yield return new WaitForSeconds(fadeTime);

            Destroy(gameObject);
        }
    }
}