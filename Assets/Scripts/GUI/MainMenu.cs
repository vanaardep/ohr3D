using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture2D menu_background;
	public Texture2D menu_logo;
	public Texture2D menu_logo_levels;
	public Texture2D menu_splash;
	public AudioClip mainMenuClickSound;
	MovieTexture loading_video;
    public AudioSource mainMenuMusic;
	public GUIStyle mainFont;
	public GUIStyle loadFont;
	public GUIStyle smallFont;
	public string load = @"";

    //BACK BUTTON
    public GUIStyle secondaryFont;

    bool loading = false;
    public static bool splash = true;
	bool menuSelect = false;
    bool started = false;

	// Use this for initialization
	void Start () {
		Invoke ("disableSplash", 4);
       
		loading_video = (MovieTexture) Resources.Load( "loading" , typeof( MovieTexture ) );
	}
	
	// Update is called once per frame
	void Update () {
       /* if (started){ // if true, main menu is called from pause menu. Disable splash
            disableSplash();
        }*/

        
    }

	void disableSplash () {
        started = true; //Game has already started up
		splash = false;
	}

	void OnGUI () {
		// Background
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), menu_background, ScaleMode.ScaleAndCrop, true, 0F);

		// Logo
		GUI.DrawTexture(new Rect((Screen.width / 2) - 90, (Screen.height / 2) - 200, 180, 300), menu_logo, ScaleMode.StretchToFill, true, 0F);

		if (!menuSelect) {
			if (GUI.Button (new Rect (10, Screen.height - 60, 100, 50), "EXIT", mainFont)) {
				// Exit game
				SoundManagerMenu.instance.PlayMainMenuClickAudio (mainMenuClickSound);
				Application.Quit ();
			}

			/*if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 60, 80, 50), "SOUND", smallFont)) {
				// Level Select
				SoundManagerMenu.instance.PlayMainMenuClickAudio (mainMenuClickSound);
				menuSelect = true;
			}*/

			// Space line
			//GUI.Button(new Rect(Screen.width - 205, Screen.height - 62, 100, 50), "|", smallFont);

			if (GUI.Button(new Rect(Screen.width - 100, Screen.height - 60, 80, 50), "CONTROLS", smallFont))
            {
                // Controls
                SoundManagerMenu.instance.PlayMainMenuClickAudio(mainMenuClickSound);
                Application.LoadLevel ("Controls");
                //menuSelect = true;
            }

			if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 160, 100, 50), "LEVELS", mainFont)) {
				// Level Select
				SoundManagerMenu.instance.PlayMainMenuClickAudio (mainMenuClickSound);
				menuSelect = true;
				menu_logo = menu_logo_levels;
			}

			if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 220, 100, 50), "TUTORIAL", mainFont)) {
				// Level Select
				SoundManagerMenu.instance.PlayMainMenuClickAudio (mainMenuClickSound);
				Application.LoadLevelAsync ("Tutorial_Video_Title_Part1");
			}

			if (GUI.Button (new Rect (Screen.width - 120, Screen.height - 280, 100, 50), "START", mainFont)) {
				// Start game
				loading = true;
                started = true;
                mainMenuMusic.Stop();
				SoundManagerMenu.instance.PlayMainMenuClickAudio (mainMenuClickSound);
				Application.LoadLevelAsync ("Level1");
			}
		}
        else {
			// Draw click boxes for levels
			GUI.backgroundColor = Color.clear;
			if (GUI.Button (new Rect ((Screen.width / 2) - 25, (Screen.height / 2) - 190, 45, 45), "")) {
				// Tutorial
				loading = true;
				SoundManagerMenu.instance.PlayMainMenuClickAudio (mainMenuClickSound);
				Application.LoadLevelAsync ("Tutorial_Video_Title_Part1");
			}
			if (GUI.Button (new Rect ((Screen.width / 2) - 75, (Screen.height / 2) - 160, 45, 45), "")) {
				// Level 1
				loading = true;
				SoundManagerMenu.instance.PlayMainMenuClickAudio (mainMenuClickSound);
				Application.LoadLevelAsync ("Level1");
			}
			if (GUI.Button (new Rect ((Screen.width / 2) + 30, (Screen.height / 2) - 160, 45, 45), "")) {
				// Level 2
				loading = true;
				SoundManagerMenu.instance.PlayMainMenuClickAudio (mainMenuClickSound);
				Application.LoadLevelAsync ("Level2");
			}
			if (GUI.Button (new Rect ((Screen.width / 2) - 25, (Screen.height / 2) - 70, 45, 45), "")) {
				// Level 3
				loading = true;
				SoundManagerMenu.instance.PlayMainMenuClickAudio (mainMenuClickSound);
				Application.LoadLevelAsync ("Level3");
			}

            //Back BUTTON
            if (GUI.Button(new Rect(50, Screen.height - 60, 100, 50), "BACK", secondaryFont))
            {
                Application.LoadLevel("Menu");
            }
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
