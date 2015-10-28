using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	public GUIStyle mainFont;
	public GUIStyle smallFont;
	public GUIStyle waveFont;

	public GameObject enemy;
    public GameObject Goliath;

	public float spawnrate;
	public float startTime;
	public float startTimeReset;
	public Transform[] spawnPoints;
	public AudioClip hordeSpawnSound;
	public AudioClip levelCompleteAudio;
	public AudioClip waveCompleteAudio;
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

    //JP
    public int GoliathLimit;
    private string nxtLvl;
    private int numGoliath;
    private bool doneForWave;
    private float waveTimeLimit;
    private float waveTimeConst;
    private bool flag2;

	// Loading screen
	MovieTexture loading_video;
	bool loading = false;
	bool levelComplete = false;
	AsyncOperation async;

	void Start () {
		bsm = FindObjectOfType(typeof(BatterySpawnManager)) as BatterySpawnManager;
		lsm = FindObjectOfType(typeof(LightbulbSpawnManager)) as LightbulbSpawnManager;
		numberOfEnemies = 0;
		hordeWaveCount = 0;
		timestamp = 0.0f;
		flag1 = false;
        flag2 = false;
		enemyKillCount = 0;
		barTime = 0f;
		aliveNumberOfEnemies = 0;
        numGoliath = 0;

        waveTimeConst =100;//120
        waveTimeLimit = waveTimeConst;//PERIOD TO LAST AFTER EVERY ENEMY HAS SPAWNED

        loading_video = (MovieTexture) Resources.Load( "loading" , typeof( MovieTexture ) );

		//=======
		//LEVEL 1
		//=======
		if (Application.loadedLevelName == "Level1") {
			spawnrate = 5f;//5
			startTime = 30;//30
			enemiesPerWave = 15;//15
			maxHordeWaves = 3;//3
            GoliathLimit = 3;
            nxtLvl = "Level2";
		}

		//=======
		//LEVEL 2
		//=======
		if (Application.loadedLevelName == "Level2") {
			spawnrate = 2f;
			startTime = 30.0f;
			enemiesPerWave = 17;
			maxHordeWaves = 4;//2
            GoliathLimit = 4;
            nxtLvl = "Level3";
		}

		//=======
		//LEVEL 2
		//=======
		if (Application.loadedLevelName == "Level3") {
			spawnrate = 1f;
			startTime = 30f;
			enemiesPerWave = 17;
			maxHordeWaves = 5;
            GoliathLimit = 5;
            nxtLvl = "Credit_Video";
            //NB NB NB Add epilogue video
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

    private void spawnGoliath()
    {
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(Goliath, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }

    void FixedUpdate () {
		
		barTime += Time.deltaTime;
        

		if (hordeWaveCount == maxHordeWaves + 1)
        {
			// Win level
			SoundManager.instance.PlayLevelCompleteAudio(levelCompleteAudio);
			levelComplete = true;
			Time.timeScale = 0;
			Invoke ("showLoadingScreen", 3);
		}

		// Cant do this
		// if (hordeWaveCount != maxHordeWaves) { 

			//countdown timer of next wave
			if (hordeSpawnTime >= 0)
            {
				hordeSpawnTime = Mathf.FloorToInt (startTime - barTime + 1f);
			} else {
				//hordeSpawnTime = Mathf.FloorToInt(1f);
			}
			
			//iterates once a wave
			//sets up wave
			if ((barTime >= startTime) && (numberOfEnemies == 0) && flag1 == false)
            {
                if (!flag2)
                {
                    enemyKillCount = enemiesPerWave;
                    timestamp = spawnrate + barTime;
                    SoundManager.instance.PlayEnvironmentAudio(hordeSpawnSound);
                        if (hordeWaveCount != maxHordeWaves)
                        {
                            hordeWaveCount++;
                        }
                        else
                        {
                            levelComplete = true;
                             timestamp = 1f;
                         }
                    flag1 = true;
                    flag2 = true;
                }
			}

			//iterates for every enemy spawned in wave
			//spawns an enemy
			if ((barTime >= timestamp) && (numberOfEnemies != enemiesPerWave) && (flag1 == true))
            {	
				spawn ();
				timestamp += spawnrate;
                int ranGen = Random.Range(0, 4);
                    if (numGoliath!=GoliathLimit && ranGen ==1 && !doneForWave)
                    {
                         numGoliath++;
                         spawnGoliath();
                         doneForWave = true;
                    }
					
			}

			//iterates after last enemy in a wave has spawned
			//resets the wave so first if statement will execute and after a wave time limit has been reached (to counteract the time taken for enemy to reach player)

			if (numberOfEnemies == enemiesPerWave) {
				
				flag1 = false;
                waveTimeLimit -= Time.deltaTime;

            	if (waveTimeLimit <= 0) {

                        flag2 = false;
                        waveTimeLimit = waveTimeConst;
                        doneForWave = false;

                        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                        foreach (GameObject enemy in enemies) {

                            enemy.GetComponent<Animator>().Play("die");

                        }
                        
                        numberOfEnemies = 0;
                        hordeSpawnTime = startTimeReset;
                        startTime = startTimeReset;
                        startTime = barTime + startTime;
                        bsm.batterySpawnLoad();
                        lsm.lightbulbSpawnLoad();
                        SoundManager.instance.PlayWaveCompleteAudio(waveCompleteAudio);
                    }
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
				GUI.Label (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 50, 100, 100), "Level Complete", mainFont);
				loading = true;
			}
		}

		// Loading
		if (loading) {
            Time.timeScale = 0;
            GUI.depth = 0;
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), loading_video, ScaleMode.ScaleAndCrop, true, 0F);
			loading_video.Play();
			loading_video.loop = true;
            //async = Application.LoadLevelAsync(nxtLvl);
				Application.LoadLevel(nxtLvl);


            //Invoke ("showLoadedScene", 5);
            //async.allowSceneActivation = false;

        }
	}

	void showLoadedScene () {
		async.allowSceneActivation = true;
	}
}
