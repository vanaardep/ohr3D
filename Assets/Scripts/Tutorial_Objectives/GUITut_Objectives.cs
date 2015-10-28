using UnityEngine;
using System.Collections;

public class GUITut_Objectives : MonoBehaviour {

	public Transform mainCamera;
	public Transform baseCar;
	public GUIStyle dialogFont;
	public float dialogTimer;
	
	public string bottomText;
	
	MovieTexture loading_video;
	bool loading = false;
	float loadTimer = 0;

	private AudioSource[] allAudioSources;
	
	// Use this for initialization
	void Start () {
		loading_video = (MovieTexture) Resources.Load( "loading" , typeof( MovieTexture ) );
	}

	void OnLevelWasLoaded(int level) {
		if (level == 8) {
			print ("TUT objectives loaded");

			loadTimer = Time.time;
		}
		
	}

	// Update is called once per frame
	void Update () {
		dialogTimer = Time.time - loadTimer;
		
		// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> SKIP TUT 
		if (Input.GetKeyUp (KeyCode.Space)) {
			endTutorial();
		}
	}
	
	void OnGUI () {
		
		Debug.Log (dialogTimer);
		
		// 1st dialog
		if (dialogTimer < 10) {
			bottomText = "Light.";
		} else if (dialogTimer < 15) {
			bottomText = "Your primary objective is to protect yourself.";
		} else if (dialogTimer < 20) {
			bottomText = "Your secondary objective is to protect your base vehicle. It stores the power for your weapons in the form of batteries.";
		} else if (dialogTimer < 25) {
			bottomText = "Your enemy is darkness itself.";
		} else if (dialogTimer < 35) {
			bottomText = "Light bulbs are used to upgrade your defences, batteries are used to power them.";
		} else if (dialogTimer < 45) {
			bottomText = "They can be found near cars, buildings and rubish heaps.";
		} else {
			bottomText = "";

			// Show gui
			GameObject theOwner = GameObject.Find("GUIObj");
			PlayerGUI_Tut script = theOwner.GetComponent<PlayerGUI_Tut>();
			script.showGUI = true;
		}
		
		// Draw label
		GUI.Label (new Rect (30, Screen.height - 70, Screen.width - 60, 70), bottomText, dialogFont);
		GUI.Label (new Rect (Screen.width - 150, 10, 140, 80), "Press Space to skip tutorial part 1.", dialogFont);
		
		if (loading) {
			GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), loading_video, ScaleMode.ScaleAndCrop, true, 0F);
			loading_video.Play();
			loading_video.loop = true;
		}
	}
	
	public void endTutorial () {
		loading = true;
		StopAllAudio ();
		Application.LoadLevel ("Tutorial_Video_Title_Part2"); 
	}

	void StopAllAudio() {
		allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
		foreach( AudioSource audioS in allAudioSources) {
			audioS.Stop();
		}
	}
}
