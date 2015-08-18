using UnityEngine;
using System.Collections;

public class BuildDefenceObject : MonoBehaviour {

	public static int signalCount;
	//public Transform pylon;
	//public AudioClip buildSound;
	// Use this for initialization
	void Start () {
		signalCount = 4;
	}

	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetKeyDown (KeyCode.E)) { //Deploy light pylon
			
			Debug.Log(">>>> Place pylon");
			if(PlayerGUI.batteryPerc > 15)
			{

				Vector3 playerPosition = GameObject.Find("Auron").transform.position;

				GameObject thisObject = Instantiate(Resources.Load("pylon"), playerPosition, Quaternion.identity) as GameObject;
				thisObject.transform.Translate(transform.forward * 1);
				PlayerGUI.batteryPerc -=15;
			}
			//SoundManager.instance.PlaySingle(buildSound);
		}
		if (Input.GetKeyDown (KeyCode.Q)) { //Deploy mine
			
			Debug.Log(">>>> Place mine");
			if( PlayerGUI.batteryPerc > 10)
			{
			
				Vector3 playerPosition = GameObject.Find("Auron").transform.position;
				
				GameObject thisObject = Instantiate(Resources.Load("lightMine"), playerPosition, Quaternion.identity) as GameObject;
				thisObject.transform.Translate(transform.forward * 1);
				PlayerGUI.batteryPerc -=10;
			}
			//SoundManager.instance.PlaySingle(buildSound);
		}

		if (Input.GetKeyDown (KeyCode.R)) { //Deploy light turret
			
			Debug.Log(">>>> Place light turret");
			if(PlayerGUI.batteryPerc > 10)
			{
				Vector3 playerPosition = GameObject.Find("Auron").transform.position;
				
				GameObject thisObject = Instantiate(Resources.Load("turretPrefab"), playerPosition, Quaternion.identity) as GameObject;
				thisObject.transform.Translate(transform.forward * 1);
				PlayerGUI.batteryPerc-=10;

			}
			//SoundManager.instance.PlaySingle(buildSound);
		}

		if (Input.GetKeyDown (KeyCode.G)) { //Deploy glowStick
			
			Debug.Log(">>>> Place glowStick");
			if(signalCount >=0)
			{
				Vector3 playerPosition = GameObject.Find("Auron").transform.position;
				
				GameObject thisObject = Instantiate(Resources.Load("glowStick"), playerPosition, transform.rotation) as GameObject;
				signalCount--;
			}
			//thisObject.transform.Translate(transform.forward * 1);  // Disabled so that glow stick is place underneath player, else it is placed next to him.
			//SoundManager.instance.PlaySingle(buildSound);
		}
	}
}
