using UnityEngine;
using System.Collections;

public class GUITut_level1 : MonoBehaviour {

	public Texture2D pause_background;
	public GUIStyle dialogFont;
	public float dialogTimer;
	
	public string bottomText;

	bool pressedSpace;

	// Use this for initialization
	void Start () {
		pressedSpace = false;
	}
	
	// Update is called once per frame
	void Update () {

		dialogTimer = Time.time;

		if (Input.GetKey (KeyCode.Escape)) {
			Time.timeScale = 1;
			pressedSpace = true;
		}
	}

	void OnGUI () {

		// 1st dialog
		if (dialogTimer < 20 && !pressedSpace) {
			bottomText = "HINT: You have 30 seconds. Scavenge as many batteries and light bulbs as you can.";
			//Time.timeScale = 0;
		} else if (dialogTimer > 20 && dialogTimer < 40) {
			bottomText = "HINT: You have 10 seconds left, get back to base to start placing defences.";
		} else if (dialogTimer > 40 && dialogTimer < 50) {
			bottomText = "HINT: Press E to place a Defence Pylon.";
		} else if (dialogTimer > 50 && dialogTimer < 60) {
			bottomText = "HINT: Press Q to place Light Mines near your base car.";
		} else if (dialogTimer > 60 && dialogTimer < 70) {
			bottomText = "HINT: Press R to place a Light Turret.";
		} else if (dialogTimer > 70 && dialogTimer < 80) {
			bottomText = "HINT: Now use RIGHT CLICK to shoot your Tesla glove and kill enemies.";
		} else {
			bottomText = "";
		}

		// Background
		//GUI.DrawTexture (new Rect (Screen.width / 2 - 175, Screen.height / 2 - 175, 350, 100), pause_background, ScaleMode.ScaleToFit, true, 0F);
		// Draw label
		GUI.Label (new Rect (30, 50, Screen.width - 60, 70), bottomText, dialogFont);

		if (bottomText != "") {
			//GUI.Label (new Rect (30, 75, Screen.width - 60, 70), ">Press 'Space' to continue<", dialogFont);
		}
	}
}
