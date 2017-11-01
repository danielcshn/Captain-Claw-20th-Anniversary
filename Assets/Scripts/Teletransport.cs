using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Teletransport : MonoBehaviour {
    // Para almacenar el destino del Warp
    public GameObject target;

    void Awake()
    {
        // Nos aseguraremos de que target se ha establecido o lanzaremos error
        //Assert.IsNotNull(target);

        // Si queremos podemos esconder los Warps
        //GetComponent<SpriteRenderer>().enabled = false;
        //transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player") {
            print("ok");
            col.transform.position = target.transform.position;
        }
    }
}