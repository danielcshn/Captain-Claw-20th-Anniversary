using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Animator;
using UnityEngine.Assertions;

public class Teletransport : MonoBehaviour {
    // Para almacenar el destino del Warp
    public GameObject target;

    // Para controlar si empieza o no la transición
    bool start = false;
    // Para controlar si la transición es de entrada o salida
    bool isFadeIn = false;
    // Opacidad inicial del cuadrado de transición
    float alpha = 0;
    // Transición de 1 segundo
    float fadeTime = 1f;

    void Start()
    {

    }

    void Awake()
    {
        // Nos aseguraremos de que target se ha establecido o lanzaremos error
        //Assert.IsNotNull(target);

        // Si queremos podemos esconder los Warps
        //GetComponent<SpriteRenderer>().enabled = false;
        //transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    /*void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") {
            print("ok");
            col.transform.position = target.transform.position;
        }
    }*/

    IEnumerator OnTriggerEnter2D(Collider2D col)
    {
        // Al chocar el jugador contra el warp comprobamos si es el jugador y lo transportamos
        if (col.CompareTag("Player"))
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            //audio.Play(44100);

            // Empezamos la trancisión fadeIn y desactivamos los controles de animación y movimiento
            FadeIn();
            col.GetComponent<Animator>().enabled = false;
            col.GetComponent<PlayerManager>().enabled = false;

            //col.GetComponent<Animator>().sprite = "Idle_0";

            // Esperamos el tiempo que dura la transición
            yield return new WaitForSeconds(fadeTime);

            // Actualizamos la posición y cámara, deshacemos transición y reactivamos los controles
            col.transform.position = target.transform.position;
            FadeOut();
            col.GetComponent<Animator>().enabled = true;
            col.GetComponent<PlayerManager>().enabled = true;

            // Por último mostramos el nombre de la zona 2 segundos
            //StartCoroutine(area.GetComponent<Area>().ShowArea("Bonus Area"));
        }
    }

    // Dibujaremos un cuadrado con opacidad encima de la pantalla simulando una transición
    void OnGUI()
    {

        // Si no empieza la transición salimos del evento directamente
        if (!start)
            return;

        // Si ha empezamos creamos un color con una opacidad inicial a 0
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        // Creamos una textura temporal para rellenar la pantalla
        Texture2D tex;
        tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.black);
        tex.Apply();

        // Dibujamos la textura sobre toda la pantalla
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

        // Controlamos la transparencia
        if (isFadeIn)
        {
            // Si es la de aparecer le sumamos opacidad
            alpha = Mathf.Lerp(alpha, 1.1f, fadeTime * Time.deltaTime);
        }
        else
        {
            // Si es la de desaparecer le restamos opacidad
            alpha = Mathf.Lerp(alpha, -0.1f, fadeTime * Time.deltaTime);
            // Si la opacidad llega a 0 desactivamos la transición
            if (alpha < 0) start = false;
        }

    }

    // Método para activar la transición de entrada
    void FadeIn()
    {
        start = true;
        isFadeIn = true;
    }

    // Método para activar la transición de salida
    void FadeOut()
    {
        isFadeIn = false;
    }
}