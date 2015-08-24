using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	public GameObject enemy;
	public float spawntime;
	public float startTime;
	public Transform[] spawnPoints;
	public AudioClip hordeSpawnSound;
	private bool soundplayed;
	int numberOfEnemies = 1;
	
	void Start () {
		//This function calls the spawn method repeatedly every 3 seconds
		soundplayed = false;
		//spawntime = 3f;
		//startTime = 30f;
		numberOfEnemies = 1;
		InvokeRepeating ("spawn", startTime, spawntime);
	}

	/**
	 * function spawn() creates an enemy at one of the spawn points
	 * */
	void spawn()
	{
		 //will stop the spawning function once player or base health reaches 0
		/*if (PlayerHealth.playerHealth <= 0 || BaseCarHealth.baseCarHealth <=0) 
		{
			return;
		}*/
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		numberOfEnemies++;

		if (numberOfEnemies > 20) {
			//CancelInvoke ("spawn");
			return;
		}
		//Debug.Log ("Spawned enemy");
	}
	
	void Update () {
		if ((Time.time >= startTime) && (soundplayed == false)) {
			SoundManager.instance.PlaySingle(hordeSpawnSound);
			soundplayed = true;
		}
	}
}