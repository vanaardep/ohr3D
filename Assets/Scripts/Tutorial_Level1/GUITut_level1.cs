﻿using UnityEngine;
using System.Collections;

public class GUITut_level1 : MonoBehaviour {

	public GUIStyle dialogFont;
	public float dialogTimer;
	
	public string bottomText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		dialogTimer = Time.time;
	}

	void OnGUI () {

		// 1st dialog
		if (dialogTimer < 10) {
			bottomText = "You have 60 seconds. Scavenge as many batteries and light bulbs as you can.";
		} else if (dialogTimer > 30 && dialogTimer < 35) {
			bottomText = "You have 30 seconds left, get back to base to start placing defences.";
		} else if (dialogTimer > 35 && dialogTimer < 40) {
			bottomText = "Press E to place a Defence Pylon on each of the 3 red spots.";
		} else if (dialogTimer > 40 && dialogTimer < 45) {
			bottomText = "Press Q to place Light Mines near your base car.";
		} else if (dialogTimer > 45 && dialogTimer < 50) {
			bottomText = "Now use F to shoot your Tesla glove and kill enemies.";
		} else {
			bottomText = "";
		}

		// Draw label
		GUI.Label (new Rect (30, 50, Screen.width - 60, 70), bottomText, dialogFont);
	}
}
