using UnityEngine;
using System.Collections;

public class BuildDefenceObject : MonoBehaviour {

	public static int signalCount;
	private int constructionTime;
	public AudioClip buildSound;
	public AudioClip constructionTimeSoundBegin;
	public AudioClip constructionTimeSoundEnd;
	// Use this for initialization
	void Start () {
		signalCount = 4;
		constructionTime = 5;
	}

	//Construction Time for a pylon
	IEnumerator PylonConstructionTime(Vector3 playerPosition, Vector3 playerRelative, GameObject constructor) {
        print(Time.time);
        yield return new WaitForSeconds(constructionTime);
        Destroy(constructor);
		GameObject thisObject = Instantiate(Resources.Load("pylon"), playerPosition, Quaternion.identity) as GameObject;
	
		thisObject.transform.position = playerPosition + playerRelative * 1;
		SoundManager.instance.PlaySingle(constructionTimeSoundEnd);

        print(Time.time);
    }

    //Construction Time for a light turret
    IEnumerator LightTurretConstructionTime(Vector3 playerPosition, Vector3 playerRelative, GameObject constructor) {
        print(Time.time);
        yield return new WaitForSeconds(constructionTime);
		Destroy(constructor);
		GameObject thisObject = Instantiate(Resources.Load("turretPrefab"), playerPosition, Quaternion.identity) as GameObject;

		thisObject.transform.position = playerPosition + playerRelative * 1;
		SoundManager.instance.PlaySingle(constructionTimeSoundEnd);

        print(Time.time);
    }


	void LateUpdate () {

		if (Input.GetKeyDown (KeyCode.E)) { //Deploy light pylon
			if(PlayerGUI.batteryPerc > 15) {
				Vector3 playerPosition = GameObject.Find("Auron").transform.position;
				Vector3 playerRelative = GameObject.Find("Auron").transform.forward;
				GameObject constructor = Instantiate(Resources.Load("Construction"), playerPosition, Quaternion.identity) as GameObject;

				constructor.transform.position = playerPosition + playerRelative * 1;

				PlayerGUI.batteryPerc -=15;
				SoundManager.instance.PlaySingle(constructionTimeSoundBegin);

				StartCoroutine(PylonConstructionTime(playerPosition, playerRelative, constructor));
			}
		}

		if (Input.GetKeyDown (KeyCode.R)) { //Deploy light turret
			if(PlayerGUI.batteryPerc > 10) {
				Vector3 playerPosition = GameObject.Find("Auron").transform.position;
				Vector3 playerRelative = GameObject.Find("Auron").transform.forward;
				GameObject constructor = Instantiate(Resources.Load("Construction"), playerPosition, Quaternion.identity) as GameObject;

				constructor.transform.position = playerPosition + playerRelative * 1;

				PlayerGUI.batteryPerc -=10;
				SoundManager.instance.PlaySingle(constructionTimeSoundBegin);

				StartCoroutine(LightTurretConstructionTime(playerPosition, playerRelative, constructor));
			}
		}

		if (Input.GetKeyDown (KeyCode.Q)) { //Deploy mine
			
			//Debug.Log(">>>> Place mine");
			if( PlayerGUI.batteryPerc > 10)
			{
			
				Vector3 playerPosition = GameObject.Find("Auron").transform.position;
				
				GameObject thisObject = Instantiate(Resources.Load("lightMine"), playerPosition, Quaternion.identity) as GameObject;
				thisObject.transform.Translate(transform.forward * 1);
				PlayerGUI.batteryPerc -=10;
			}
			SoundManager.instance.PlaySingle(buildSound);
		}

		if (Input.GetKeyDown (KeyCode.G)) { //Deploy glowStick
			
			//Debug.Log(">>>> Place glowStick");
			if(signalCount >=0)
			{
				Vector3 playerPosition = GameObject.Find("Auron").transform.position;
				
				GameObject thisObject = Instantiate(Resources.Load("glowStick"), playerPosition, transform.rotation) as GameObject;
				signalCount--;
			}
			//thisObject.transform.Translate(transform.forward * 1);  // Disabled so that glow stick is place underneath player, else it is placed next to him.
			SoundManager.instance.PlaySingle(buildSound);
		}
	}
}
