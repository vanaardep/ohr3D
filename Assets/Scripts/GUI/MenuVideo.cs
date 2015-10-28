using UnityEngine;
using System.Collections;

public class MenuVideo : MonoBehaviour {

	MovieTexture intro_video;

	private AudioSource[] allAudioSources;

	// Use this for initialization
	void Start () {
		intro_video = (MovieTexture) Resources.Load( "gameIntro" , typeof( MovieTexture ) );
		Invoke ("videoDone", 53);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			endTutorial();
		}
	}

	void OnGUI () {
		
		// Game over video
		intro_video.Play ();
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), intro_video, ScaleMode.ScaleAndCrop, true, 0F);
	}

	void videoDone () {
		Application.LoadLevel ("Menu");
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
