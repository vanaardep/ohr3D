using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {
	public AudioClip Footstep1;
	public AudioClip Footstep2;
	public AudioClip Footstep3;
	public AudioClip Footstep4;
	public AudioClip Jump;
	public AudioClip Land;
	// Use this for initialization
	void Start () {
	
	}
	/*
	 * All of the functions are called as animation events
	 * 
	 * */
	// Update is called once per frame
	void Update () {
	
	}
	public void playJump(){
		SoundManager.instance.PlaySingle (Jump);
	}
	public void playLand(){
		SoundManager.instance.PlaySingle (Land);
	}
	public void playFootsteps(){
		SoundManager.instance.RandomizeSfx(Footstep1,Footstep2,Footstep3,Footstep4);
	}
}
