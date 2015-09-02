using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

	//Player has to kill 20 enemies in a horde wave
	//Once done, player has 30 seconds to collect droppables
	//Horde comes after 30 seconds starting from when the last enemy died from the last horde wave

	public GUIStyle mainFont;
	public GUIStyle smallFont;
	public GUIStyle waveFont;

	public GameObject enemy;
	public float spawnrate;
	public float startTime;
	public float startTimeReset;
	public Transform[] spawnPoints;
	public AudioClip hordeSpawnSound;
	int numberOfEnemies = 0;

	public float hordeSpawnTime;
	public int hordeWaveCount;
	public int maxHordeWaves;
	public static int enemyKillCount = 0;
	private float timestamp;
	public int enemiesPerWave;
	private bool flag1 = false;
	public BatterySpawnManager bsm;
	public LightbulbSpawnManager lsm;
	
	void Start () {
		bsm = FindObjectOfType(typeof(BatterySpawnManager)) as BatterySpawnManager;
		lsm = FindObjectOfType(typeof(LightbulbSpawnManager)) as LightbulbSpawnManager;
		numberOfEnemies = 0;
		hordeWaveCount = 0;
		timestamp = 0.0f;

		//edit these to adjust difficulty of the game
		//spawnrate = 3.0f;
		//startTime = 30.0f;
		//startTimeReset = 30.0f; //must be the same as startTime always changed from 30
		//enemiesPerWave = 20;
		//maxHordeWaves = 6;
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

		if(hordeWaveCount != maxHordeWaves) {

			//countdown timer of next wave
			if(hordeSpawnTime >= 0){
				hordeSpawnTime = Mathf.FloorToInt(startTime - Time.time);
			}
			else {
				//hordeSpawnTime =  0;
			}
			
			//iterates once a wave
			//sets up wave
			if ((Time.time >= startTime)  && (numberOfEnemies == 0) && flag1 == false) {
				enemyKillCount = enemiesPerWave;
				timestamp = spawnrate + Time.time;	
				SoundManager.instance.PlaySingle(hordeSpawnSound);
				hordeWaveCount++;
				flag1 = true;
			}

			//iterates for every enemy spawned in wave
			//spawns an enemy
			if((Time.time >= timestamp)&& (numberOfEnemies != enemiesPerWave) && (flag1 == true)) {	
				spawn();
				timestamp += spawnrate;
					
			}

			//iterates after last enemy in a wave has spawned
			//resets the wave so first if statement will execute
			if(numberOfEnemies == enemiesPerWave && enemyKillCount == 0) {
				flag1 = false;
				numberOfEnemies = 0;
				hordeSpawnTime = startTimeReset;
				startTime = startTimeReset;
				startTime = Time.time + startTime;
				bsm.batterySpawnLoad();
				lsm.lightbulbSpawnLoad();
			}
		}
	}

	void OnGUI(){
		//GUI.Box (new Rect (0, 200, 190, 50), "Horde wave: " + hordeWaveCount + "/6" );
		//GUI.Box (new Rect (0, 250, 190, 50), "Next Horde wave spawns in: " + hordeSpawnTime);
		//GUI.Box (new Rect (0, 300, 200, 50), "Enemies left: " + enemyKillCount + "num: " + numberOfEnemies);
		//GUI.Box (new Rect (0, 350, 190, 50), "startTime:" + startTime + "TIME: " + Time.time);

		GUI.Label (new Rect (Screen.width - 100, 0, 100, 80), "" + hordeSpawnTime, mainFont);
		GUI.Label (new Rect (Screen.width - 100, 40, 100, 100), "NEXT WAVE", smallFont);
		GUI.Label (new Rect (Screen.width / 2 - 50, 0, 100, 70), "WAVE " + hordeWaveCount + "/6", waveFont);
	}
}
