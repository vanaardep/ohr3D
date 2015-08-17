using UnityEngine;
using System.Collections;

public class BuildDefenceObject : MonoBehaviour {

	//public Transform pylon;
	//public AudioClip buildSound;
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetKeyDown (KeyCode.E)) { //Deploy light pylon
			
			Debug.Log(">>>> Place pylon");

			Vector3 playerPosition = GameObject.Find("Auron").transform.position;

			GameObject thisObject = Instantiate(Resources.Load("pylon"), playerPosition, Quaternion.identity) as GameObject;
			thisObject.transform.Translate(transform.forward * 1);
			//SoundManager.instance.PlaySingle(buildSound);
		}
		if (Input.GetKeyDown (KeyCode.Q)) { //Deploy mine
			
			Debug.Log(">>>> Place mine");
			
			Vector3 playerPosition = GameObject.Find("Auron").transform.position;
			
			GameObject thisObject = Instantiate(Resources.Load("lightMine"), playerPosition, Quaternion.identity) as GameObject;
			thisObject.transform.Translate(transform.forward * 1);
			//SoundManager.instance.PlaySingle(buildSound);
		}

		if (Input.GetKeyDown (KeyCode.R)) { //Deploy light turret
			
			Debug.Log(">>>> Place light turret");
			
			Vector3 playerPosition = GameObject.Find("Auron").transform.position;
			
			GameObject thisObject = Instantiate(Resources.Load("turretPrefab"), playerPosition, Quaternion.identity) as GameObject;
			thisObject.transform.Translate(transform.forward * 1);
			//SoundManager.instance.PlaySingle(buildSound);
		}

		if (Input.GetKeyDown (KeyCode.G)) { //Deploy glowStick
			
			Debug.Log(">>>> Place glowStick");
			
			Vector3 playerPosition = GameObject.Find("Auron").transform.position;
			
			GameObject thisObject = Instantiate(Resources.Load("glowStick"), playerPosition, transform.rotation) as GameObject;
			//thisObject.transform.Translate(transform.forward * 1);  // Disabled so that glow stick is place underneath player, else it is placed next to him.
			//SoundManager.instance.PlaySingle(buildSound);
		}
	}
}
