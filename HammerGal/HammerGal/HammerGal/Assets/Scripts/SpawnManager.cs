using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	public GameObject[] platforms;
	private PlatformData[] platformsData;
	public string[] setups;
	public Transform spawnPoint;
	private Transform lastObject;
	private int lastObjectData;
	public int objectCount;
	public GameObject enemy;

	// Use this for initialization
	void Start () {
		lastObject = spawnPoint;
		lastObjectData = 0;
		objectCount = 0;
		loadData ();
	}
	
	// Update is called once per frame
	void Update () {
		if (objectCount < 25) {
			spawn ();
		}
	}

	public void spawn()
	{
		//float posX = Random.Range (lastObject.x-5, lastObject.x+5);
		//float posY = Random.Range (0,1-(Mathf.Abs(lastObject.x-posX)/5));
		int modifier = (Random.Range(0,2)>0.5f) ? 1 :-1;
		bool spawnEnemy = true;//(Random.Range(0,10)>3f) ? true : false;
		int numPlat = Random.Range (0, platforms.Length);
		float verticalOffset = (modifier == 1) ? platformsData[lastObjectData].RightOffset : platformsData[lastObjectData].LeftOffset;
		//Debug.Log ("Random: "+Random.Range(0,2));
		int setup = Random.Range(0, setups.Length-1);
		string[] values = setups [setup].Split(':');


		float posX = lastObject.position.x + (float.Parse(values[0]) * modifier) + verticalOffset;
		float posY = (lastObject.position.y - spawnPoint.position.y) + float.Parse(values[1]) + platformsData[lastObjectData].HeightOffset;

		lastObjectData = numPlat;

		if (posX < -8 || posX + platformsData[numPlat].PlatformLength > 8) {
			 posX = lastObject.position.x + (float.Parse(values[0]) * -modifier) + verticalOffset;
		} 
		Vector3 pos = new Vector3 (posX, spawnPoint.position.y+posY, 0);
		GameObject g = Instantiate (platforms[numPlat], pos, Quaternion.identity);
		/*if (spawnEnemy) {
			GameObject e = Instantiate (enemy, new Vector3 (posX+3, spawnPoint.position.y+posY+2, 0), Quaternion.identity);
			Vector3 temp = e.transform.localScale;
			temp.x *= -modifier;
			e.transform.localScale = temp;
		}
		if (spawnEnemy) {
			g.GetComponent<PlatformData> ().activateEnemy (0);
		}*/
		lastObject = g.transform;
		objectCount++;
	}

	private void loadData()
	{
		int pos = 0;
		platformsData = new PlatformData[platforms.Length];
		while (pos<platforms.Length) {
			platformsData [pos] = platforms [pos].GetComponent<PlatformData> ();
			pos++;
		}
	}
}
