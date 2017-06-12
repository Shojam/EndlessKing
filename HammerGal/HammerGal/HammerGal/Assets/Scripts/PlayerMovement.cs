using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	private float moveX;
	private float moveY;
	private bool jump;
	private bool canJump;
	private bool jumping;
	private bool jumpHeld;
	private bool isOnLadder;
	public bool IsOnLadder {
		get{return isOnLadder;}
		set{isOnLadder = value;}
	}
	private bool climbing;
	private bool hasSwing;
	public float maxSpeed;
	public string dir;
	public SwordManager sword;
	private bool facingRight;
	private Rigidbody2D rb;
	private SpriteRenderer sprite;
	Animator anim;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;



	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		facingRight = true;
		isOnLadder = false;
		dir = "Right";
		sprite = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		Ladder.OnUp += setLadder;
	}

	// Update is called once per frame
	void Update () {
		moveX = Mathf.RoundToInt(Input.GetAxis ("Horizontal"));
		moveY = Mathf.RoundToInt(Input.GetAxis ("Vertical"));
		hasSwing = Input.GetButtonDown ("Fire2");
		anim.SetFloat ("Speed", Mathf.Abs (moveX));
		if (moveX < 0 && facingRight) {
			flip ();
			dir = "Left";
		} else if (moveX > 0 && !facingRight){
			flip ();
			dir = "Right";
		}

		if(Input.GetButtonDown ("Jump"))
		{
			jump = true;
		}

		if (hasSwing) {
			sword.swing ();
		}

		jumpHeld = Input.GetButton ("Jump");


	}

	void FixedUpdate()
	{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		anim.SetBool ("Grounded", grounded);
		anim.SetBool ("IsOnLadder", isOnLadder);


		if (isOnLadder) {
			rb.gravityScale = 0;
		} else {
			rb.gravityScale = 5;
		}

		if (jumping && !jumpHeld && rb.velocity.y>0) {
			jumping = false;
			rb.velocity = new Vector2 (moveX * maxSpeed, rb.gravityScale);
		}
		else if (jump && grounded) {
			jumping = true;
			anim.SetTrigger ("Jump");
			jump = false;
			rb.velocity = new Vector2 (moveX * maxSpeed, 0);
			rb.AddForce (new Vector2 (0, 700));
		} 
		else if (isOnLadder && moveY > 0) {
			anim.SetTrigger ("Climbing");
			//rb.velocity = new Vector2 (0, moveY * maxSpeed);	
			rb.MovePosition(transform.position + transform.up*Time.deltaTime*6);
		}
		else {
			rb.velocity = new Vector2 (moveX * maxSpeed, rb.velocity.y);	
		}
			
	}

	void flip()
	{
		facingRight = !facingRight;
		Vector3 temp = transform.localScale;
		temp.x *= -1;
		transform.localScale = temp;
	}

	private void setLadder(Transform t)
	{
		setPlayerPosition (t);
		isOnLadder = true;
	}

	public void gotOffLadder()
	{
		isOnLadder = false;
		rb.velocity = new Vector2 (0, rb.gravityScale);	
	}
		
	private void setPlayerPosition(Transform t)
	{
		this.transform.position = new Vector3 (t.position.x, this.transform.position.y, this.transform.position.z);
	}

	public void OnDestroy()
	{
		Ladder.OnUp -=setLadder;
	}

}
