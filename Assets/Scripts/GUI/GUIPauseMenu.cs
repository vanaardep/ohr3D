using UnityEngine;
using System.Collections;

public class GUIPauseMenu : MonoBehaviour {

	public Texture2D pause_background;
	MovieTexture loading_video;
	public GUIStyle mainFont;
	public GUIStyle titleFont;
	public AudioClip pauseMenuClickSound;

	bool paused;
	bool loading;

	// Use this for initialization
	void Start () {
		paused = false;
		//loading = false;
		loading_video = (MovieTexture) Resources.Load( "loading" , typeof( MovieTexture ) );
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

			if (loading) {
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), loading_video, ScaleMode.ScaleAndCrop, true, 0F);
				loading_video.Play();
				loading_video.loop = true;
				Application.LoadLevelAsync (Application.loadedLevel);
			}

			// Background
			GUI.DrawTexture (new Rect (Screen.width / 2 - 125, Screen.height / 2 - 125, 250, 250), pause_background, ScaleMode.ScaleToFit, true, 0F);

			// Paused
			GUI.Label (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 110, 100, 50), "PAUSED", titleFont);

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 10, 100, 50), "Quit to Menu", mainFont)) {
				// Save and Quit game
				SoundManagerMenu.instance.PlayMainMenuClickAudio(pauseMenuClickSound);
				Application.LoadLevel("Menu");
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 + 40, 100, 50), "Exit Game", mainFont)) {
				// Save and Quit game
				SoundManagerMenu.instance.PlayMainMenuClickAudio(pauseMenuClickSound);
				Application.Quit ();
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 50), "Resume", mainFont)) {
				// Resume game
				SoundManagerMenu.instance.PlayMainMenuClickAudio(pauseMenuClickSound);
				paused = false;
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 20, 100, 50), "Restart Level", mainFont)) {
				// Restart level
				//paused = false;
				SoundManagerMenu.instance.PlayMainMenuClickAudio(pauseMenuClickSound);
				loading = true;
			}
		}
	}
}
