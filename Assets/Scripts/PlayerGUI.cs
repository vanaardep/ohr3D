using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

	public static int batteryPerc;

	// Use this for initialization
	void Start () {
		batteryPerc = 100;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Box (new Rect (Screen.width/2 - 290, Screen.height/2 - 150, 120, 50), "Battery : " + batteryPerc+"%" + "\n" + "Health : " + PlayerHealth.playerHealth + "\n" + "Base Health: " + BaseCarHealth.baseCarHealth);
	}
}
