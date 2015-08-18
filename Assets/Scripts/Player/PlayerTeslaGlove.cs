using UnityEngine;
using System.Collections;

public class PlayerTeslaGlove : MonoBehaviour {

	public bool gloveActive;
	public AudioClip shootSound1;
	public AudioClip shootSound2;
	public AudioClip shootSound3;
	public AudioClip shootSound4;
	private int cooldown;
	public float bulletSpeed = 1000;

	// Use this for initialization
	void Start () {
		//this.GetComponent<Light> ().intensity = 0;
		gloveActive = false;
		cooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.F)) {
			Debug.Log("Tesla shot!!!!!!!!!!!!!!!!!!!");
			if (cooldown == 0 && gloveActive == false) {
				//tesla shot creation
				//Vector3 playerPosition = GameObject.Find("Auron").transform.position + new Vector3(0, 0, 1f);
				Vector3 playerPosition = GameObject.Find("Auron").transform.position;
				 
				GameObject thisObject = Instantiate(Resources.Load("bulletPrefab"), playerPosition, Quaternion.identity) as GameObject;
				thisObject.transform.Translate(transform.forward * 1);
				thisObject.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
				thisObject.GetComponent<Rigidbody>().AddForce(transform.up * 300);

				//
				SoundManager.instance.RandomizeSfx(shootSound1, shootSound2, shootSound3, shootSound4);
				//this.GetComponent<Light> ().intensity = 200;
				gloveActive = true;
				cooldown = 5;
				Invoke ("disabletTesla", 2);
			}
		} else {
			//this.GetComponent<Light> ().intensity = 0;
			gloveActive = false;
			
		}
	}

	void disabletTesla () {
		//this.GetComponent<Light> ().intensity = 0;
		gloveActive = false;

		InvokeRepeating ("coolDownDec", 0, 1f);
	}

	void coolDownDec () {
		if (cooldown > 0) {
			cooldown--;
		} else {
			CancelInvoke ("coolDownDec");
		}
	}

	void OnGUI(){
		GUI.Box (new Rect (0, 200, 120, 40), "COOLDOWN: " + cooldown);
	}
}
