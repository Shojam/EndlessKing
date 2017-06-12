using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusMovement : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D rb;
	public Vector2 force; 
	public Vector2 rebound;
	private bool bounced;
	public delegate void pickedUpAction();
	public static event pickedUpAction OnPickedUp;

	void Awake () {
		bounced = false;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void launchCactus(float dir)
	{		
		rb.AddForce (new Vector2 (force.x * dir, force.y));	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.gameObject.tag.Equals ("Enemy")) {
			Destroy (other.collider.gameObject);
		} else if (other.collider.gameObject.tag.Equals ("Player") && bounced) {
			OnPickedUp ();
			bounced = false;
		}
		if (other.collider.gameObject.tag.Equals ("Hazard") ) {
			this.gameObject.SetActive (false);
		}
		if (!bounced && !other.gameObject.tag.Equals ("Player")) {
			rb.velocity = new Vector2 (rebound.x, rebound.y);
			bounced = true;
		}
	}

}
