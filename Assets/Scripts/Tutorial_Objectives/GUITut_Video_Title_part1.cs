using UnityEngine;
using System.Collections;

public class GUITut_Video_Title_part1 : MonoBehaviour {

	MovieTexture tutorial_video;

	// Use this for initialization
	void Start () {
		tutorial_video = (MovieTexture) Resources.Load( "ohr_tutorial_title_part1" , typeof( MovieTexture ) );
		Invoke ("videoDone", 4);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		
		// Game over video
		tutorial_video.Play ();
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), tutorial_video, ScaleMode.ScaleAndCrop, true, 0F);
	}

	void videoDone () {
		Application.LoadLevel ("Tutorial_Objectives");
	}
}
