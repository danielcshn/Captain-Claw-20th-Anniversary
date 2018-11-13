using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderUP : MonoBehaviour {

	public float speed = 5f;
	private Rigidbody2D rb;
	private Animator animationObj;
	private float inputHorizontal;
	private float inputVertical;

	public float distance = 1f;
	public LayerMask whatIsLadder;
	public string ladderTag = "Ladder"; // Tag Ladder
	private Vector3 ladderPos;
	public bool isLadder;
	public bool isClimbing;

	public LadderDown ladderdown;

	void Start () {
		rb = GetComponent<Rigidbody2D>();
		animationObj = GetComponent<Animator>();
	}

void FixedUpdate(){

		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);
	
		if(hitInfo.collider != null){
			if(Input.GetKeyDown(KeyCode.UpArrow)){
				isClimbing = true;
			}
			if(ladderdown.DownLadderNow && isLadder){
				isClimbing = true;
			}
		} else {
			isClimbing = false;
		}

		if(isClimbing == true){
			inputVertical = Input.GetAxisRaw("Vertical");
			inputHorizontal = Input.GetAxisRaw("Horizontal");
			rb.velocity = new Vector2(0, inputVertical * speed);
            //rb.transform.Translate(0, inputVertical * speed, 0);
			rb.gravityScale = 0;
            animationObj.Play("claw_climbing");

			float xPos = Mathf.Lerp(transform.position.x, ladderPos.x, 10 * Time.deltaTime);
			transform.position = new Vector2(xPos, transform.position.y); // плавное выравнивание по центру лестницы

		} else {
			rb.gravityScale = 1;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == ladderTag && !isLadder)
		{
			ladderPos = other.transform.position;
			isLadder = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == ladderTag)
		{
			isLadder = false;
			isClimbing = false;
			ladderdown.DownLadderNow = false;
			animationObj.Play("claw_idle");
		}
	}

}
