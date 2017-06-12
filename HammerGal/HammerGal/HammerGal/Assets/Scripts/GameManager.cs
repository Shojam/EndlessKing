using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public static GameManager instance = null;
	public float speed;
	public GameObject[] platforms;
	private PlatformData[] platformsData;
	public string[] setups;
	public Transform spawnPoint;
	private Transform lastObject;
	private int lastObjectData;
	private int objectCount;
	private SpawnManager spawner;
	//public GameObject gameOverPanel;
	public static AudioSource song;

	void Awake()
	{

		if (instance == null) {

			instance = this;
		}
		else if(instance != this)
		{
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
		//gameOverPanel.SetActive (false);
	}

	void Start () {
		StartCoroutine ("increaseDificulty");
		//Debug.Log ("Restarted");
		spawner = FindObjectOfType<SpawnManager> ();

	}

	void OnLevelWasLoaded(int aLevelID)
	{
		spawner = FindObjectOfType<SpawnManager> ();
	}

	// Update is called once per frame
	void Update () {

	}
		


	/*public IEnumerator spawner()
	{
		while (true) {
			spawn ();
			yield return new WaitForSeconds (15f/speed);
		}
	}*/

	/*public void spawn()
	{
		//float posX = Random.Range (lastObject.x-5, lastObject.x+5);
		//float posY = Random.Range (0,1-(Mathf.Abs(lastObject.x-posX)/5));
		int modifier = (Random.Range(0,2)>0.5f) ? 1 :-1;
		int numPlat = Random.Range (0, platforms.Length);
		float verticalOffset = (modifier == 1) ? platformsData[lastObjectData].RightOffset : platformsData[lastObjectData].LeftOffset;
		Debug.Log ("Random: "+Random.Range(0,2));
		int setup = Random.Range(0, setups.Length-1);
		string[] values = setups [setup].Split(':');


		float posX = lastObject.position.x + (float.Parse(values[0]) * modifier) + verticalOffset;
		float posY = (lastObject.position.y - spawnPoint.position.y) + float.Parse(values[1]) + platformsData[lastObjectData].HeightOffset;

		lastObjectData = numPlat;

		if (posX < -8) {
			posX = -8;
		} else if (posX + platformsData[numPlat].PlatformLength > 8) {
			posX = 8 - platformsData[numPlat].PlatformLength;
		}
		Vector3 pos = new Vector3 (posX, spawnPoint.position.y+posY, 0);
		GameObject g = Instantiate (platforms[numPlat], pos, Quaternion.identity);
		lastObject = g.transform;
		objectCount++;
	}*/



	public void decreaseObjects()
	{
		spawner.objectCount--;
	}
		
	public IEnumerator increaseDificulty()
	{
		while (true) {
			yield return new WaitForSeconds (10f);
			speed += 2;
			Debug.Log ("Speed: " + speed);
		}
	}

	public void reset()
	{
		StartCoroutine ("restart");
	}

	private IEnumerator restart()
	{
		//gameOverPanel.SetActive (true);
		speed = 15;
		yield return new WaitForSeconds (3f);
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);

	}
}
