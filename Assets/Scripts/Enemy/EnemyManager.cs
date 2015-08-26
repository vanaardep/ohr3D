using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	//Player has to kill 20 enemies in a horde wave
	//Once done, player has 30 seconds to collect droppables
	//Horde comes after 30 seconds starting from when the last enemy died from the last horde wave

	public GameObject enemy;
	public float spawnrate;
	public float startTime;
	public Transform[] spawnPoints;
	public AudioClip hordeSpawnSound;
	int numberOfEnemies = 0;

	//edits
	public float hordeSpawnTime;
	public float hordeWaveCount = 0;
	public static int enemyKillCount = 0;
	private float timestamp;

	private bool flag1 = false;
	
	void Start () {
		spawnrate = 3.0f;
		startTime = 30.0f;
		numberOfEnemies = 0;
		hordeWaveCount = 0;
		timestamp = 0.0f;
	}

	/**
	 * function spawn() creates an enemy at one of the spawn points
	 * */
	private void spawn()
	{
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		numberOfEnemies++;
	}
	
	void FixedUpdate () {

		if(hordeSpawnTime >= 0){
			hordeSpawnTime = Mathf.FloorToInt(startTime - Time.time);
		}
		else {
			//hordeSpawnTime =  0;
		}
		

		//iterates once a wave
		if ((Time.time >= startTime)  && (numberOfEnemies == 0) && flag1 == false) {
			enemyKillCount = 20;
			timestamp = spawnrate + Time.time;	
			SoundManager.instance.PlaySingle(hordeSpawnSound);
			hordeWaveCount++;
			flag1 = true;
		}

		//iterates for every enemy spawned in wave
		if((Time.time >= timestamp)&& (numberOfEnemies != 20) && (flag1 == true)) {	
			spawn();
			timestamp += spawnrate;
				
		}

		//iterates after last enemy in a wave has spawned
		if(numberOfEnemies == 20 && enemyKillCount == 0) {
			flag1 = false;
			hordeSpawnTime = 30.0f;
			numberOfEnemies = 0;
			startTime = Time.time + startTime;

			BatterySpawnManager batterySpawnManager = GetComponent<BatterySpawnManager>();
			batterySpawnManager.batterySpawnLoad();
			LightbulbSpawnManager lightbulbSpawnManager = GetComponent<LightbulbSpawnManager>();
			lightbulbSpawnManager.lightbulbSpawnLoad();

			

			Debug.Log ("RESEEEEEEEEEEEEEEEEEEEEET :D");
		}
	}

	void OnGUI(){
		GUI.Box (new Rect (0, 200, 190, 50), "Horde wave: " + hordeWaveCount + "/6" + "timestamp:" + timestamp);
		GUI.Box (new Rect (0, 250, 190, 50), "Next Horde wave spawns in: " + hordeSpawnTime);
		GUI.Box (new Rect (0, 300, 200, 50), "Enemies left: " + enemyKillCount + "num: " + numberOfEnemies);
	}
}
