using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	MovieTexture loading_video;
	MovieTexture over_video;
	bool loading = false;
	public GUIStyle mainFont;
	public AudioClip gameOverMenuClickSound;

	bool gameOverDone = false;

	void Start () {
		loading_video = (MovieTexture) Resources.Load( "loading" , typeof( MovieTexture ) );
		over_video = (MovieTexture) Resources.Load( "gameOver" , typeof( MovieTexture ) );

		//float duration = over_video.duration;
		//Debug.Log (duration);
		Invoke ("videoDone", 8f);
	}

	void Update () {

	}

	void videoDone () {
		gameOverDone = true;
	}

	void OnGUI () {

		// Game over video
		over_video.Play();
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), over_video, ScaleMode.ScaleAndCrop, true, 0F);

		// Add buttons
		if (gameOverDone) {

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 50), "RESTART", mainFont)) {
				// Start game
				SoundManagerMenu.instance.PlayMainMenuClickAudio(gameOverMenuClickSound);
				loading = true;
				loading_video.Play();
				loading_video.loop = true;

				// Get last loaded level
				Application.LoadLevelAsync (PlayerPrefs.GetString("LoadedLevel"));
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 0, 100, 50), "MAIN MENU", mainFont)) {
				// Start game
				SoundManagerMenu.instance.PlayMainMenuClickAudio(gameOverMenuClickSound);
				loading = true;
				Application.LoadLevel("Menu");
			}

			// Loading
			if (loading) {
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), loading_video, ScaleMode.ScaleAndCrop, true, 0F);
			}
		}
	}
}
