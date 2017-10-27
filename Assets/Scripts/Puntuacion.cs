using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puntuacion : MonoBehaviour
{

    private int puntuacion = 00000000;
    public TextMesh marcador;

    // Use this for initialization
    void Start()
    {
        NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
        ActualizarMarcador();
    }

    void IncrementarPuntos(Notification notificacion)
    {
        int puntosAIncrementar = (int)notificacion.data;
        puntuacion += puntosAIncrementar;
        ActualizarMarcador();
    }

    void ActualizarMarcador()
    {
        marcador.text = puntuacion.ToString("D8");
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
