using UnityEngine;
using System.Collections;

public class LightbulbSpawnManager : MonoBehaviour {

	public GameObject lightbulb;
	public Transform[] lightbulbSpawnPoints;

	// Use this for initialization
	void Start () {

		lightbulbSpawn();
		lightbulbSpawn();
		lightbulbSpawn();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void lightbulbSpawn()
	{
		int spawnPointIndex = Random.Range (0, lightbulbSpawnPoints.Length);
		Instantiate (lightbulb, lightbulbSpawnPoints [spawnPointIndex].position, lightbulbSpawnPoints [spawnPointIndex].rotation);
	}

}
