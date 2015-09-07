using UnityEngine;
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
	MovieTexture loading_video;
	bool loading = false;
	public GUIStyle mainFont;


	private float FadeinDelay = 0f;

	void Start () {
		FadeinDelay = 0f;
		Renderer rend = this.GetComponent<Renderer>();
		rend.material.mainTexture = Texture2D.blackTexture;

		if(Film == true){
			PictureRateInSeconds = 0.055f;//0.04166666666666666666f;
		}
		
		Object[] textures  = Resources.LoadAll(imageFolderName);
		for(var i = 0; i <= 177; i += 2) // Put 3 to load less images, faster load, changed to 167 to not load text images
		{
			pictures.Add(textures[i]);
		}

		loading_video = (MovieTexture) Resources.Load( "loading" , typeof( MovieTexture ) );
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

		FadeinDelay += Time.deltaTime;
	}



	void OnGUI () {

		//GUI.color.a = alpha;
		if (imageSeqDone) {
		/*Color thisColor = GUI.color;
		thisColor.a = 0;
		GUI.color = thisColor;

		if (FadeinDelay > 7 ) {

			//Fade in
			//GUI.color.a = 
			//Debug.Log ("Inside");
			//Debug.Log ("Time : " + Time.deltaTime);
			thisColor.a = (Time.time - 3)/5;
			//thisColor.a = 
			GUI.color = thisColor;
		}*/

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 50), "RESTART", mainFont)) {
				// Start game
				loading = true;
				loading_video.Play();
				loading_video.loop = true;
				Application.LoadLevelAsync ("Level1");
			}

			if (GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 0, 100, 50), "MAIN MENU", mainFont)) {
				// Start game
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
