using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemManager : MonoBehaviour {

	// Use this for initialization
	private SpriteRenderer sprite;
	private BoxCollider2D col;
	private Color tempColor;
	public delegate void ActivateAction();
	public event ActivateAction OnActivate;
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		col = GetComponent<BoxCollider2D> ();
		tempColor = sprite.color;
		sprite.color = Color.gray;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.gameObject.tag.Equals ("Projectile")) {
			col.enabled = false;
			sprite.color = tempColor;
			OnActivate ();
		}
	}
}
