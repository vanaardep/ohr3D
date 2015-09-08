using UnityEngine;
using System.Collections;

public class GUITutorial : MonoBehaviour {

	public GUIStyle dialogFont;
	public float dialogTimer;

	public string bottomText;

	MovieTexture loading_video;
	bool loading = false;

	// Player tests
	float timeElapsed = 0;
	bool usedTesla = false;
	bool usedPylon = false;
	bool usedGlowstick = false;
	bool usedMine = false;
	bool usedTurret = false;

	// Use this for initialization
	void Start () {
		loading_video = (MovieTexture) Resources.Load( "loading" , typeof( MovieTexture ) );
	}
	
	// Update is called once per frame
	void Update () {
		dialogTimer = Time.time;

		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> SKIP TUT 
		if (Input.GetKeyUp (KeyCode.Escape)) {
			endTutorial();
		}

		// Used tesla glove
		if (Input.GetKeyUp (KeyCode.F)) {
			usedTesla = true;
		}

		// Used pylon
		if (Input.GetKeyUp (KeyCode.E)) {
			usedPylon = true;
		}

		// Used turret
		if (Input.GetKeyUp (KeyCode.R)) {
			usedTurret = true;
		}

		// Used Mine
		if (Input.GetKeyUp (KeyCode.Q)) {
			usedMine = true;
		}

		// Used Glowstick
		if (Input.GetKeyUp (KeyCode.G)) {
			usedGlowstick = true;
		}
	}

	void OnGUI () {

		//Debug.Log (dialogTimer);

		// 1st dialog
		if (dialogTimer < 3) {
			bottomText = "Where am I...";
		} else if (dialogTimer < 6) {
			bottomText = "Son, I'm here to explain to you how to survive in this cruel world.";
		} else if (dialogTimer < 9) {
			bottomText = "Your objective is to protect both yourself and your base vehicle. Your first line of defence is your torch, shine it at a creature of darkness to stun them.";
		} else if (dialogTimer < 12) {
			bottomText = "To move, use the W A S D keys.";
		} else if (!usedTesla){
			bottomText = "Once you are ready, press 'F' to use your testla glove to banish the creature.";
			timeElapsed = dialogTimer;
		}

		// Test used tesla
		if (usedTesla) {
			bottomText = "Good! This may work for one creature of darkness, but for many you will have to get more creative with your defences.";

			if (dialogTimer - timeElapsed > 6) {
				bottomText = "For a stronger defence, you can place Light Pylons which ward off creatures of darkness. To place one press 'E'";
			}
		}

		// Test used pylon
		if (usedPylon) {
			bottomText = "Now, being warned of approaching creatures is important. A Glowstick will warn you of nearby creatures by glowing brighter as they approach. To place one press 'G'.";
		}

		// Test used glow
		if (usedGlowstick) {
			bottomText = "Great! To destroy creatures of darkness before they reach you or your base vehicle, you can place Light Mines. To place one press 'Q'.";
		}

		// Test used turret
		if (usedMine) {
			bottomText = "Good. Your final means of attack is a Light Turret. A Light Turrent will destroy creatures if they enter it's attack radius. To place one press 'R'.";
		}

		// Test used glow
		if (usedTurret) {
			bottomText = "You are now ready to fight off creatures of darkness. Goodluck.";
			Invoke ("endTutorial", 4);
		}

		// Draw label
		GUI.Label (new Rect (30, Screen.height - 70, Screen.width - 60, 70), bottomText, dialogFont);
		GUI.Label (new Rect (Screen.width - 140, 10, 130, 70), "Press Esc to Skip.", dialogFont);

		if (loading) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), loading_video, ScaleMode.ScaleAndCrop, true, 0F);
			loading_video.Play();
			loading_video.loop = true;
		}
	}

	void endTutorial () {
		loading = true;
		Application.LoadLevel ("Level1");
	}
}
