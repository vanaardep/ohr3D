using UnityEngine;
using System.Collections;

public class PlayerSounds : MonoBehaviour {
	public AudioClip Footstep1;
	public AudioClip Footstep2;
	public AudioClip Footstep3;
	public AudioClip Footstep4;
	public AudioClip Grasstep1;
	public AudioClip Grasstep2;
	public AudioClip Grasstep3;
	public AudioClip Grasstep4;
	public AudioClip Grasstep5;
	public AudioClip Grasstep6;
	public AudioClip Jump;
	public AudioClip Land;
    public Animator _animator;
	// Use this for initialization
	void Start () {
        _animator = GetComponent<Animator>();
	}
	/*
	 * All of the functions are called as animation events
	 * 
	 * */
	// Update is called once per frame
	void Update () {
	
	}
	public void playJump(){
		SoundManager.instance.PlayPlayerMoveAudio(Jump);
	}
	public void playLand(){
		SoundManager.instance.PlayPlayerMoveAudio(Land);
	}
	public void playFootsteps(){
        if (_animator.GetFloat("Forward") > 0.2)
        {
            if (Application.loadedLevelName == "Level1" || Application.loadedLevelName == "Level3" || Application.loadedLevelName == "Tutorial")
            {
                SoundManager.instance.PlayPlayerMoveAudio(Footstep1, Footstep2, Footstep3, Footstep4);
            }
            else
            {
                SoundManager.instance.PlayPlayerMoveAudio(Grasstep1, Grasstep2, Grasstep3, Grasstep4, Grasstep5, Grasstep6);
                Debug.Log("called");
            }
        }
	}
    public void playNothing(){

    }
}
