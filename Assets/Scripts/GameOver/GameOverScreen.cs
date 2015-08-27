﻿using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	public string imageFolderName = "PicSeq";
	private Shader shad1;
	public bool MakeTexture = false;
	public ArrayList pictures = new ArrayList();
	public bool loop = false;
	public int counter = 0;
	public bool Film = true;
	public float PictureRateInSeconds = 1f;
	private float nextPic = 1f;

	private bool imageSeqDone = false;
	public Texture2D load_screen;
	bool loading = false;
	public GUIStyle mainFont;

	void Start () {

		Renderer rend = this.GetComponent<Renderer>();
		rend.material.mainTexture = Texture2D.blackTexture;

		if(Film == true){
			PictureRateInSeconds = 0.055f;//0.04166666666666666666f;
		}
		
		Object[] textures  = Resources.LoadAll(imageFolderName);
		for(var i = 0; i <= 167; i += 3) // Put 3 to load less images, faster load, changed to 167 to not load text images
		{
			pictures.Add(textures[i]);
		}
	
	}
	

	void Update () {
		if (Time.time > nextPic && counter != pictures.Count) {
			if (MakeTexture) {
				Renderer rend = this.GetComponent<Renderer> ();
				rend.material.mainTexture = (Texture2D)pictures [counter];

			}
			nextPic = Time.time + PictureRateInSeconds;
			counter += 1;

			if(counter == pictures.Count)
			{
				Debug.Log ("DONE");
				imageSeqDone = true;
			}
		}		
	}

	void OnGUI () {
		if (imageSeqDone) {

			//Debug.Log ("Add button");

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 50), "RESTART", mainFont)) {
				// Start game
				loading = true;
				Application.LoadLevel("Level1");
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 0, 100, 50), "MAIN MENU", mainFont)) {
				// Start game
				loading = true;
				Application.LoadLevel("Menu");
			}

			// Loading
			if (loading) {
				GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), load_screen, ScaleMode.ScaleAndCrop, true, 0F);
			}
		}
	}
}
