using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamPlayer: MonoBehaviour {

    public Transform objetive;
    public float cleanering = 5f;

    Vector3 desface;
     
	// Use this for initialization
	void Start () {
        desface = transform.position - objetive.position;
	}

    private void FixedUpdate()
    {
        Vector3 positionObketive = objetive.position + desface;
        transform.position = Vector3.Lerp(transform.position, positionObketive, cleanering * Time.deltaTime);
    }

    /* Update is called once per frame
	void Update () {
		
	}*/
}
