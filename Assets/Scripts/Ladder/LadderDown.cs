using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderDown : MonoBehaviour {

	private PlatformEffector2D effector;
	public float waitTime;
	public bool DownLadderNow = false;

	void Start () {
		effector = GetComponent<PlatformEffector2D>();
	}

	void Update () {
		if (Input.GetKeyUp(KeyCode.DownArrow)){
			waitTime = 0.2f;
		}
		if (Input.GetKey(KeyCode.DownArrow)){
			if(waitTime <= 0){
				DownLadderNow = true;
				effector.rotationalOffset = 180f;
				waitTime = 0.2f;
			} else {
				waitTime -= Time.deltaTime;
			}
		}
		if(Input.GetKey(KeyCode.UpArrow)){
			DownLadderNow = false;
			effector.rotationalOffset = 0;
		}
	}
}
