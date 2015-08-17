using UnityEngine;
using System.Collections;

public class BatterySpawnManager : MonoBehaviour {

	public GameObject battery;
	public Transform[] batterySpawnPoints;

	// Use this for initialization
	void Start () {

		//spawn 3 random batteries in the map
		batterySpawn ();
		batterySpawn ();
		batterySpawn ();
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}

	//Creates a battery at random spawn location
	void batterySpawn()
	{
		int spawnPointIndex = Random.Range (0, batterySpawnPoints.Length);
		Instantiate (battery, batterySpawnPoints [spawnPointIndex].position, batterySpawnPoints [spawnPointIndex].rotation);
	}


}
