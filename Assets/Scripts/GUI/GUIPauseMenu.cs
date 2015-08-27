using UnityEngine;
using System.Collections;

public class GUIPauseMenu : MonoBehaviour {

	public Texture2D pause_background;
	public Texture2D load_screen;
	public GUIStyle mainFont;
	public GUIStyle titleFont;

	bool paused;
	bool loading;

	// Use this for initialization
	void Start () {
		paused = false;
		//loading = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Escape)) {
			paused = true;
		}

		if (paused == true) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	void OnGUI () {

		if (paused) {
			// Background
			GUI.DrawTexture (new Rect (Screen.width / 2 - 125, Screen.height / 2 - 125, 250, 250), pause_background, ScaleMode.ScaleToFit, true, 0F);

			// Paused
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 110, 100, 50), "PAUSED", titleFont);

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 10, 100, 50), "Save and Quit", mainFont)) {
				// Save and Quit game
				Application.Quit ();
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 50), "Resume", mainFont)) {
				// Resume game
				paused = false;
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 20, 100, 50), "Restart Level", mainFont)) {
				// Restart level
				//paused = false;
				loading = true;
			}

			if (loading) {
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), load_screen, ScaleMode.ScaleAndCrop, true, 0F);
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}
}
