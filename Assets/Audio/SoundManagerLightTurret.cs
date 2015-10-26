using UnityEngine;
using System.Collections;

public class SoundManagerLightTurret : MonoBehaviour {

 	public SoundManagerLightTurret instance = null; 
    public AudioSource lightTurretAudio;


    void Start() 
    {
		AudioSource[] audios = GetComponents<AudioSource>();
        lightTurretAudio = audios[0];
    }


   void Awake ()
    {
        
        instance = this;

    }

	
	public void PlayLightTurretAttack(AudioClip clip)
    {
        lightTurretAudio.clip = clip;
        lightTurretAudio.Play ();
    }
}
