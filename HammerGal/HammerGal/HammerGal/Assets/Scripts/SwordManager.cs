using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour {

	private SpriteRenderer sprite;
	private BoxCollider2D col;
	private Animator anim;
	// Use this for initialization
	void Awake () {
		sprite = GetComponent<SpriteRenderer> ();
		sprite.enabled = false;
		anim = GetComponent<Animator> ();
		col = GetComponent<BoxCollider2D> ();
		col.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Slice")) {
			sprite.enabled = false;
			col.enabled = false;
		}
	}

	public void swing()
	{
		sprite.enabled = true;
		col.enabled = true;
		anim.SetTrigger ("Swing");
	}
}
