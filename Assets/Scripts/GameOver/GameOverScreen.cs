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


	void Start () {
		Renderer rend = this.GetComponent<Renderer>();
		rend.material.mainTexture = Texture2D.blackTexture;

		if(Film == true){
			PictureRateInSeconds = 0.04166666666666666666f;
		}
		
		Object[] textures  = Resources.LoadAll(imageFolderName);
		for(var i = 0; i < textures.Length; i++)
		{
			pictures.Add(textures[i]);
		}
	
	}
	

	void Update () {
		if(Time.time > nextPic && counter !=230 ){
			if(MakeTexture){
				Renderer rend = this.GetComponent<Renderer>();
				rend.material.mainTexture = (Texture2D)pictures[counter];

			}
			nextPic = Time.time + PictureRateInSeconds;
			counter += 1;
		}
		if(counter >= pictures.Count)
		{
			counter = 230;
			if(loop){
				counter = 0;
			}
		}
	
	}
}
