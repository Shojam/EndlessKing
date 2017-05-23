using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour {

	// Use this for initialization

    public bool rotate;
	public bool activate;
	public float speed;
    private int degrees;
	private int rotatingDir;
	public Transform destination;
	public Transform sourcePlatform;
	void Start () {
		if (rotate) {
			StartCoroutine ("movePlatform");
		}
		if (activate) {
			GetComponentInChildren<GemManager> ().OnActivate += startPlatform;
		}

	}
	
	// Update is called once per frame
	void Update () {

    }

	private void startPlatform()
	{
		StartCoroutine ("activatePlatform");
	}

	private IEnumerator activatePlatform()
	{
		while (Vector3.Distance (sourcePlatform.position, destination.position) > 1) {
			sourcePlatform.position = Vector3.MoveTowards (sourcePlatform.position, destination.position, speed * Time.deltaTime);
			yield return new WaitForEndOfFrame ();
		}
	}

	private IEnumerator movePlatform()
	{
		degrees = 0;
		rotatingDir = -1;
		while (true) {
			Debug.Log ("Hello?");
			transform.Rotate (Vector3.back, speed * Time.deltaTime * rotatingDir, Space.World);
			if (Mathf.Abs (transform.rotation.eulerAngles.z) > 179 && rotatingDir<0) {
				yield return new WaitForSeconds (0.5f);
				rotatingDir = 1;
			}
			if ((Mathf.Abs (transform.rotation.eulerAngles.z) <= 1 && rotatingDir>0) || Mathf.Abs (transform.rotation.eulerAngles.z) > 200 && rotatingDir>0) {
				yield return new WaitForSeconds (1.5f);
				rotatingDir = -1;
			}

			yield return new WaitForEndOfFrame ();

		}
	}    
}
