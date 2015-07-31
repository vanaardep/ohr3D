using UnityEngine;
using System.Collections;

public class PlayerTeslaGlove : MonoBehaviour {

	public bool gloveActive;
	public AudioClip shootSound;
	private int cooldown;

	// Use this for initialization
	void Start () {
		this.GetComponent<Light> ().intensity = 0;
		gloveActive = false;
		cooldown = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Q)) {
			if (cooldown == 0 && gloveActive == false) {
				//SoundManager.instance.PlaySingle(shootSound);
				this.GetComponent<Light> ().intensity = 100;
				gloveActive = true;
				cooldown = 5;
				Invoke ("disabletTesla", 2);
			}
		} else {
			this.GetComponent<Light> ().intensity = 0;
			gloveActive = false;
			
		}
	}

	void disabletTesla () {
		this.GetComponent<Light> ().intensity = 0;
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
