using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public GUIStyle mainFont;
	public GUIStyle smallFont;
	public GUIStyle waveFont;

	public GameObject enemy;
	public float spawnrate;
	public float startTime;
	public float startTimeReset;
	public Transform[] spawnPoints;
	public AudioClip hordeSpawnSound;
	int numberOfEnemies;

	public int aliveNumberOfEnemies;

	public float hordeSpawnTime;
	public int hordeWaveCount;
	public int maxHordeWaves;
	public static int enemyKillCount;
	private float timestamp;
	public int enemiesPerWave;
	private bool flag1;
	private float barTime;
	public BatterySpawnManager bsm;
	public LightbulbSpawnManager lsm;

	// Loading screen
	MovieTexture loading_video;
	bool loading = false;
	bool levelComplete = false;

	void Start () {
		bsm = FindObjectOfType(typeof(BatterySpawnManager)) as BatterySpawnManager;
		lsm = FindObjectOfType(typeof(LightbulbSpawnManager)) as LightbulbSpawnManager;
		numberOfEnemies = 0;
		hordeWaveCount = 0;
		timestamp = 0.0f;
		flag1 = false;
		enemyKillCount = 0;
		barTime = 0f;
		aliveNumberOfEnemies = 0;

		loading_video = (MovieTexture) Resources.Load( "loading" , typeof( MovieTexture ) );

		//=======
		//LEVEL 1
		//=======
		if (Application.loadedLevelName == "Level1") {
			spawnrate = 5.0f;
			startTime = 60.0f;
			enemiesPerWave = 5;
			maxHordeWaves = 2;
		}

		//=======
		//LEVEL 2
		//=======
		if (Application.loadedLevelName == "Level2") {
			spawnrate = 3.0f;
			startTime = 60.0f;
			enemiesPerWave = 8;
			maxHordeWaves = 2;
		}

		//=======
		//LEVEL 2
		//=======
		if (Application.loadedLevelName == "Level3") {
			spawnrate = 3.0f;
			startTime = 60.0f;
			enemiesPerWave = 12;
			maxHordeWaves = 2;
		}

		startTimeReset = startTime;
	}

	/**
	 * function spawn() creates an enemy at one of the spawn points
	 * */
	private void spawn()
	{
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		numberOfEnemies++;
		aliveNumberOfEnemies++;
	}

	void FixedUpdate () {
		
		barTime += Time.deltaTime;

		if (hordeWaveCount == maxHordeWaves + 1) {
			// Win level
			levelComplete = true;
			Time.timeScale = 0;
			Invoke ("showLoadingScreen", 3);
		}

		// Cant do this
		// if (hordeWaveCount != maxHordeWaves) { 

			//countdown timer of next wave
			if (hordeSpawnTime >= 0) {
				hordeSpawnTime = Mathf.FloorToInt (startTime - barTime + 1f);
			} else {
				//hordeSpawnTime = Mathf.FloorToInt(1f);
			}
			
			//iterates once a wave
			//sets up wave
			if ((barTime >= startTime) && (numberOfEnemies == 0) && flag1 == false) {
				enemyKillCount = enemiesPerWave;
				timestamp = spawnrate + barTime;	
				SoundManager.instance.PlayEnvironmentAudio (hordeSpawnSound);
				hordeWaveCount++;
				flag1 = true;
			}

			//iterates for every enemy spawned in wave
			//spawns an enemy
			if ((barTime >= timestamp) && (numberOfEnemies != enemiesPerWave) && (flag1 == true)) {	
				spawn ();
				timestamp += spawnrate;
					
			}

			//iterates after last enemy in a wave has spawned
			//resets the wave so first if statement will execute

			if (numberOfEnemies == enemiesPerWave) {
				//if (aliveNumberOfEnemies == 0 && numberOfEnemies == enemiesPerWave)
				flag1 = false;
				numberOfEnemies = 0;
				hordeSpawnTime = startTimeReset;
				startTime = startTimeReset;
				startTime = barTime + startTime;
				bsm.batterySpawnLoad ();
				lsm.lightbulbSpawnLoad ();
			}
	}

	void showLoadingScreen (){
		loading = true;
		loading_video.Play();
		loading_video.loop = true;
	}

	void OnGUI(){
		/*GUI.Box (new Rect (0, 200, 190, 50), "Horde wave: " + hordeWaveCount + "/6" );
		GUI.Box (new Rect (0, 250, 190, 50), "Next Horde wave spawns in: " + hordeSpawnTime);
		GUI.Box (new Rect (0, 300, 200, 50), "Enemies left: " + enemyKillCount + "num: " + numberOfEnemies);
		GUI.Box (new Rect (0, 350, 190, 50), "startTime:" + startTime + "TIME: " + barTime);*/

		if (!loading) {

			bool waveComplete = false;

			if (hordeSpawnTime >= 0) {
				GUI.Label (new Rect (Screen.width - 100, 0, 100, 80), "" + hordeSpawnTime, mainFont);
				GUI.Label (new Rect (Screen.width - 100, 40, 100, 100), "NEXT WAVE", smallFont);

				if (hordeWaveCount > 1) {
					waveComplete = true;
				}
			} else {
				GUI.Label (new Rect (Screen.width - 100, 0, 100, 80), "0", mainFont);
				GUI.Label (new Rect (Screen.width - 100, 40, 100, 100), "Survive!", smallFont);
			}

			GUI.Label (new Rect (Screen.width / 2 - 50, 0, 100, 70), "WAVE " + hordeWaveCount + "/" + maxHordeWaves, waveFont);

			// Wave completed
			if (waveComplete) {
				GUI.Label (new Rect (30, 50, Screen.width - 60, 70), "Wave Complete!", smallFont);
			}

			// Win screen
			if (levelComplete) {
				GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 100, 100, 100), "Level Complete", mainFont);
			}
		}

		// Loading
		if (loading) {
			GUI.depth = 0;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), loading_video, ScaleMode.ScaleAndCrop, true, 0F);
			loading_video.Play();
			loading_video.loop = true;
			Application.LoadLevelAsync("Level2");
		}
	}
}
