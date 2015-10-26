using UnityEngine;
using System.Collections;

public class SoundManagerPylon : MonoBehaviour 
{
    public SoundManagerPylon instance = null; 
    AudioSource audios;

    void Start() 
    {
        audios = this.GetComponent<AudioSource>();

    }


   void Awake ()
    {
        
        instance = this;

    }


	public void PlayLightpylonBuzz()
	{
		this.audios.mute = false;
	}

	public void MuteLightpylonBuzz()
	{
		this.audios.mute = true;
	}
}