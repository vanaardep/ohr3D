using UnityEngine;
using System.Collections;

public class BuildDefenceObject : MonoBehaviour {

	//public Transform pylon;
	public AudioClip buildSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyUp (KeyCode.E)) { //Deploy light pylon
			
			Debug.Log(">>>> Place pylon");

			Vector3 playerPosition = GameObject.Find("Auron").transform.position;

			GameObject thisObject = Instantiate(Resources.Load("pylon"), playerPosition, Quaternion.identity) as GameObject;
			SoundManager.instance.PlaySingle(buildSound);
		}
		if (Input.GetKeyUp (KeyCode.Q)) { //Deploy light pylon
			
			Debug.Log(">>>> Place mine");
			
			Vector3 playerPosition = GameObject.Find("Auron").transform.position;
			
			GameObject thisObject = Instantiate(Resources.Load("lightMine"), playerPosition, Quaternion.identity) as GameObject;
			SoundManager.instance.PlaySingle(buildSound);
		}

		if (Input.GetKeyUp (KeyCode.R)) { //Deploy light turret
			
			Debug.Log(">>>> Place light turret");
			
			Vector3 playerPosition = GameObject.Find("Auron").transform.position;
			
			GameObject thisObject = Instantiate(Resources.Load("turretPrefab"), playerPosition, Quaternion.identity) as GameObject;
			SoundManager.instance.PlaySingle(buildSound);
		}
	}
}
