using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	//Player has to kill 20 enemies in a horde wave
	//Once done, player has 30 seconds to collect droppables
	//Horde comes after 30 seconds starting from when the last enemy died from the last horde wave

	public GameObject enemy;
	public float spawntime;
	public float startTime;
	public Transform[] spawnPoints;
	public AudioClip hordeSpawnSound;
	private bool soundplayed = false;
	int numberOfEnemies = 0;

	//edits
	public float hordeSpawnTime;
	public float hordeWaveCount = 1;
	public static int enemyKillCount = 20;
	
	void Start () {
		//This function calls the spawn method repeatedly every 3 seconds
		soundplayed = false;
		spawntime = 3f;
		startTime = 30f;
		numberOfEnemies = 0;
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

		if (numberOfEnemies >= 20) {
			numberOfEnemies = 0;
			CancelInvoke ("spawn");
			return;
		}
		//Debug.Log ("Spawned enemy");
	}
	
	void Update () {

		hordeSpawnTime = 0;
		if ((Time.time >= startTime) && (enemyKillCount == 0) && (!IsInvoking("spawn"))) {
			
			enemyKillCount = 20;
			hordeSpawnTime = startTime - Time.time;
			startTime = Time.time + startTime;
			InvokeRepeating ("spawn", startTime, spawntime);
			SoundManager.instance.PlaySingle(hordeSpawnSound);
			soundplayed = false;
			hordeWaveCount++;
			
		}
	}

	void OnGUI(){
		GUI.Box (new Rect (0, 200, 100, 50), "Horde wave: " + hordeWaveCount + "/6");
		GUI.Box (new Rect (0, 250, 170, 50), "Next Horde wave spawns in: " + hordeSpawnTime);
		GUI.Box (new Rect (0, 300, 170, 50), "Enemies left: " + enemyKillCount);
	}
}
