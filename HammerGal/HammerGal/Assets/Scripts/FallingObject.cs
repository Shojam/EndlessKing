using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour {

	// Use this for initialization
	public bool enabled;
	private Rigidbody2D rb;
	private float speed;
	public float speedModifier;

	void Start () {
		
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		speed = GameManager.instance.speed;
		if (enabled) {
			rb.MovePosition (transform.position + (Vector3.up*-1) * Time.deltaTime * speed/10 * (1-speedModifier)/1);
		}
	}
}
