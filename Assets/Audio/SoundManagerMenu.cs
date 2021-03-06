﻿using UnityEngine;
using System.Collections;

    public class SoundManagerMenu : MonoBehaviour 
    {
        public AudioSource mainMenuClickAudio;
        public AudioSource mainMenuHoverAudio;
        public AudioSource menuDenyAudio;
        public AudioSource musicSource;   
        public static SoundManagerMenu instance = null;                    


        void Start() {
            AudioSource[] audios = GetComponents<AudioSource>();
            mainMenuClickAudio = audios[0];
            mainMenuHoverAudio = audios[1];
            menuDenyAudio = audios[2];
        }     
        
        
        void Awake ()
        {
           if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy (gameObject);
            
            DontDestroyOnLoad (gameObject);
        }


        public void PlayMainMenuClickAudio(AudioClip clip)
        {
            mainMenuClickAudio.clip = clip;
            mainMenuClickAudio.Play ();
        }

        public void PlayMainMenuHoverAudio(AudioClip clip)
        {
            mainMenuHoverAudio.clip = clip;
            mainMenuHoverAudio.Play ();
        }

        public void PlayMenuDenyAudio(AudioClip clip)
        {
            menuDenyAudio.clip = clip;
            menuDenyAudio.Play ();
        }

}