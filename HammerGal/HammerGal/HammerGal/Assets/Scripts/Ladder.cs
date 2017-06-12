using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

	public bool enabled;
	private bool up;
	public delegate void UpAction(Transform pos);
	public static event UpAction OnUp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (enabled) {
			up = (Mathf.RoundToInt(Input.GetAxis ("Vertical"))>0)?true:false;
			if (up) {
				if (OnUp != null) {
					OnUp (this.transform);
				}
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag.Equals ("LadderCheck")) {
			enabled = true;

		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.tag.Equals ("LadderCheck")) {
			enabled = false;
			other.gameObject.GetComponentInParent<PlayerMovement> ().gotOffLadder();
		}
	}


}
