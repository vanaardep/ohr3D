using UnityEngine;
using System.Collections;

public class GameOverScreen : MonoBehaviour {

	// Use this for initialization
	public string imageFolderName = "PicSeq";
	public bool MakeTexture = false;
	public ArrayList pictures = new ArrayList();
	//public Object[] textures;
	public bool loop = false;
	public int counter = 0;
	public bool Film = true;
	public float PictureRateInSeconds = 1f;
	private float nextPic = 1f;


	void Start () {
		Renderer rend = this.GetComponent<Renderer>();
		rend.material.mainTexture = Texture2D.blackTexture;
		if(Film == true){
			PictureRateInSeconds = 0.04166666666666666666f;
		}
		
		Object[] textures  = Resources.LoadAll(imageFolderName);
		for(var i = 0; i < textures.Length; i++){
			//Debug.Log("found");
			pictures.Add(textures[i]);
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextPic && counter !=230 ){
			/*nextPic = Time.time + PictureRateInSeconds;
			counter += 1;*/
			if(MakeTexture){
				Renderer rend = this.GetComponent<Renderer>();

				//Renderer.material.mainTexture = pictures[counter];
				rend.material.mainTexture = (Texture2D)pictures[counter];

			}
			nextPic = Time.time + PictureRateInSeconds;
			counter += 1;
		}
		if(counter >= pictures.Count){
			Debug.Log("fertig");
			counter = 230;
			if(loop){
				counter = 0;
			}
		}
	
	}
}
