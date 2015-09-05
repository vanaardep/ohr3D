using UnityEngine;
using System.Collections;

public class GUITutorial : MonoBehaviour {

	public GUIStyle dialogFont;
	public float dialogTimer;
	public float dialogTime;

	public string bottomText;

	// Player tests
	bool usedTesla = false;

	// Use this for initialization
	void Start () {
		dialogTime = 4;
	}
	
	// Update is called once per frame
	void Update () {
		dialogTimer = Time.time;

		// Used tesla gloce
		if (Input.GetKeyUp (KeyCode.F)) {
			usedTesla = true;
		}
	}

	void OnGUI () {

		Debug.Log (dialogTimer);

		// 1st dialog
		if (dialogTimer < dialogTime) {
			bottomText = "Where am I...";
		} else if (dialogTimer < dialogTime + 3) {
			bottomText = "Son, I'm here to explain to you how to survive in this cruel world.";
		} else if (dialogTimer < dialogTime + 6) {
			bottomText = "Your first line of defence is your torch, shine it at a creature of darkness to stun them.";
		} else {
			bottomText = "Once you are able, press 'F' to use your testla glove to banish the creature.";
		}

		// Test used tesla
		if (usedTesla) {
			bottomText = "Good! This may work for one creature of darkness, but for many you will have to get more creative with your defences.";
		}

		GUI.Label (new Rect (30, Screen.height - 70, Screen.width - 60, 70), bottomText, dialogFont);
	}
}
