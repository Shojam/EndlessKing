using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusManager : MonoBehaviour {

	// Use this for initialization
	private SpriteRenderer cactusHat;
	public Transform cactusPosition;
	public GameObject cactusPrefab;
	private GameObject cactus;
	private CactusMovement cactusMove;
	private bool fire;
	private bool cactusReady;
	void Awake () {
		cactusHat = GetComponentsInChildren<SpriteRenderer> ()[1];
		CactusMovement.OnPickedUp += resetCactus;
		//cactusPosition = cactusHat.transform;
		fire = false;
	}

	void Start()
	{
		cactusReady = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!fire) {
			fire = Input.GetButtonDown ("Fire1");
		}
		if (fire) {
			Debug.Log ("Update lo cogio");
		}
	}

	void FixedUpdate()
	{
		if (fire) {
			Debug.Log ("FixedUpdate lo cogio");
			throwCactus ();
		}
	}

	private void throwCactus ()
	{
		fire = false;
		if (cactusReady) {
			Debug.Log ("Tried to throw");
			cactusReady = false;
			cactusHat.enabled = false;
			if (cactus == null) {
				cactus = Instantiate (cactusPrefab, cactusPosition.position, Quaternion.identity);
				cactusMove = cactus.GetComponent<CactusMovement> ();
			}
			cactus.transform.position = cactusPosition.position;
			cactus.SetActive (true);
			cactusMove.launchCactus (transform.localScale.x);
		}
	}

	private void resetCactus()
	{
		cactusHat.enabled = true;
		cactus.SetActive (false);
		cactusReady = true;
	}


	public void OnDestroy()
	{
		CactusMovement.OnPickedUp -= resetCactus;
	}

}
