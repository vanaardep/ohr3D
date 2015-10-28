using UnityEngine;
using System.Collections;

public class GUICredits_Video : MonoBehaviour {

	MovieTexture credit_video;
	public GUIStyle dialogFont;

	private AudioSource[] allAudioSources;

	// Use this for initialization
	void Start () {
		credit_video = (MovieTexture) Resources.Load( "CreditVideo" , typeof( MovieTexture ) );
		Invoke ("endTutorial", 45);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			endTutorial();
		}
	}

	void OnGUI () {
		
		// video
		credit_video.Play ();
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), credit_video, ScaleMode.ScaleAndCrop, true, 0F);

		// Skip button
		GUI.Label (new Rect (Screen.width - 150, Screen.height - 80, 140, 80), "Press Space to skip tutorial part 2.", dialogFont);
	}

	public void endTutorial () {
		StopAllAudio ();
		Application.LoadLevel ("Menu");
	}

	void StopAllAudio() {
		allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		foreach( AudioSource audioS in allAudioSources) {
			audioS.Stop();
		}
	}
}
