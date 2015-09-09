using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture2D menu_background;
	public Texture2D menu_splash;
	public AudioClip mainMenuClickSound;
	MovieTexture loading_video;

	public GUIStyle mainFont;
	public GUIStyle loadFont;
	public string load = @"";

	bool loading = false;
	bool splash = true;

	// Use this for initialization
	void Start () {
		Invoke ("disableSplash", 4);

		loading_video = (MovieTexture) Resources.Load( "loading" , typeof( MovieTexture ) );
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
			SoundManagerMenu.instance.PlayMainMenuClickAudio(mainMenuClickSound);
			Application.Quit();
		}

		if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 120, 100, 50), "START", mainFont)) {
			// Start game
			loading = true;
			SoundManagerMenu.instance.PlayMainMenuClickAudio(mainMenuClickSound);
			Application.LoadLevelAsync("Tutorial");
		}

		// Splash
		if (splash) {
			GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), menu_splash, ScaleMode.ScaleAndCrop, true, 0F);
		}

		// Loading
		if (loading) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), loading_video, ScaleMode.ScaleAndCrop, true, 0F);
			loading_video.Play();
			loading_video.loop = true;
		}
	}
}
