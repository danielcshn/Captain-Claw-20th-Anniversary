using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Player))]
public class PlayerAnim : MonoBehaviour {

	private Animator animator;
	public float directional;

	void Awake(){
		animator = GetComponent<Animator>();
	}

	void Update(){
		Player variable = GetComponent<Player>();
		directional = variable.directionalInput.x;
	}

	void FixedUpdate () {

		if (directional == 1){
			animator.SetFloat("speed", 1);
		}
		if (directional == -1){
			animator.SetFloat("speed", 1);
		}
		if (directional == 0){
			animator.SetFloat("speed", 0);
		}
	}
}
