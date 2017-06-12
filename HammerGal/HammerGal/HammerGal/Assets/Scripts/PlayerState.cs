using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerState : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.gameObject.tag.Equals ("Hazard") || other.collider.gameObject.tag.Equals ("Enemy") ) {
			Reset ();
			this.gameObject.SetActive (false);
		}
	}

	private void Reset()
	{
		GameManager.instance.reset ();
	}
}
