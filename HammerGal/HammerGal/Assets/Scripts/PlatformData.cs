using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformData : MonoBehaviour {

	public float heightOffset;
	public float HeightOffset {
		get{return heightOffset;}
	}
	public float leftOffset;
	public float LeftOffset {
		get{return leftOffset*-1;}
	}
	public float rightOffset;
	public float RightOffset {
		get{return rightOffset;}
	}

	public float platformLength;
	public float PlatformLength {
		get{return platformLength;}
	}

	public GameObject[] enemiesSpawn;
	public GameObject[] enemies;

	public void activateEnemy(int id)
	{
		if (enemiesSpawn.Length > 0) {
			//Debug.Log("try");
			Instantiate (enemies[id], enemiesSpawn [id].transform.position, Quaternion.identity, transform);
		}
	}

}
