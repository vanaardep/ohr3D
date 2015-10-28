using UnityEngine;
using System.Collections;

public class LightbulbSpawnManager : MonoBehaviour {

	public GameObject lightbulb;
	public Transform[] lightbulbSpawnPoints;
	public 

	// Use this for initialization
	void Start () {

		lightbulbSpawnLoad();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void lightbulbSpawn()
	{
		int spawnPointIndex = Random.Range (0, lightbulbSpawnPoints.Length);
		Instantiate (lightbulb, lightbulbSpawnPoints [spawnPointIndex].position, lightbulbSpawnPoints [spawnPointIndex].rotation);
	}

	public void lightbulbSpawnLoad()
	{
		lightbulbSpawn();
		lightbulbSpawn();
		lightbulbSpawn();
		lightbulbSpawn();
		Debug.Log ("Spawning LIIIIIIIIIIGHTBULBS");
	}

}
