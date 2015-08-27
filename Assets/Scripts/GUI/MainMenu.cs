using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture2D menu_background;
	public Texture2D menu_splash;
	public Texture2D load_screen;

	public GUIStyle mainFont;
	public GUIStyle loadFont;
	public string load = @"";

	bool loading = false;
	bool splash = true;

	// Use this for initialization
	void Start () {
		Invoke ("disableSplash", 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void disableSplash () {
		splash = false;
	}

	void OnGUI () {
		// Background
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), menu_background, ScaleMode.ScaleAndCrop, true, 0F);

		if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 60, 100, 50), "EXIT", mainFont)) {
			// Exit game
			Application.Quit();
		}

		if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 120, 100, 50), "START", mainFont)) {
			// Start game
			loading = true;
			Application.LoadLevel("Level1");
		}

		// Splash
		if (splash) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), menu_splash, ScaleMode.ScaleAndCrop, true, 0F);
		}

		// Loading
		if (loading) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), load_screen, ScaleMode.ScaleAndCrop, true, 0F);
		}
	}
}
