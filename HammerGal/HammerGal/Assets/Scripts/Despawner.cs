﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{		
		Debug.Log ("Hellow");
		GameManager.instance.decreaseObjects ();
		Destroy (other.gameObject);
	}
}
