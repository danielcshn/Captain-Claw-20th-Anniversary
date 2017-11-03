using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    public int puntosGanados = 00000000;
    // Transición de 0.1 segundo
    float fadeTime = 0.25f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            gameObject.layer = 31;

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            //audio.Play(44100);

            // Esperamos el tiempo que dura el audio
            yield return new WaitForSeconds(fadeTime);

            NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosGanados);
            Destroy(gameObject);
        }
    }
}
