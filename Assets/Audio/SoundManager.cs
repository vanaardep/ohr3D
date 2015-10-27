using UnityEngine;
using System.Collections;

    public class SoundManager : MonoBehaviour 
    {
        public AudioSource environmentAudio;
        public AudioSource playerMoveAudio;
        public AudioSource playerShootAudio;
        public AudioSource playerDamageAudio;  
        public AudioSource buildingAudio;
        public AudioSource itemPickupAudio;
        public AudioSource baseDamageAudio;
        public AudioSource waveCompleteAudio;
        public AudioSource levelCompleteAudio;
        public AudioSource musicSource;   

        public static SoundManager instance = null;                
        public float lowPitchRange = .95f;              
        public float highPitchRange = 1.05f;      


        void Start() {
            AudioSource[] audios = GetComponents<AudioSource>();
            environmentAudio = audios[0];
            playerMoveAudio = audios[1];
            playerShootAudio = audios[2];
            playerDamageAudio = audios[3];
            buildingAudio = audios[4];
            itemPickupAudio = audios[5];
            baseDamageAudio = audios[6];
            waveCompleteAudio = audios[7];
            levelCompleteAudio = audios[8];
        }     
        
        
        void Awake ()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy (gameObject);
            
            DontDestroyOnLoad (gameObject);
        }


        //Plays audio related to environment noises
        public void PlayEnvironmentAudio(AudioClip clip)
        {
            environmentAudio.clip = clip;
            environmentAudio.Play ();
        }

        //Plays audio related to playermovement
        public void PlayPlayerMoveAudio(params AudioClip[] clips)
        {
            int randomIndex = Random.Range(0, clips.Length);
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            
            playerMoveAudio.pitch = randomPitch;
            playerMoveAudio.clip = clips[randomIndex];
            playerMoveAudio.Play();
        }

        //Plays audio related to player shoot
        public void PlayPlayerShootAudio(params AudioClip[] clips)
        {
            int randomIndex = Random.Range(0, clips.Length);
            float randomPitch = Random.Range(lowPitchRange, highPitchRange);
            
            playerShootAudio.pitch = randomPitch;
            playerShootAudio.clip = clips[randomIndex];
            playerShootAudio.Play();
        }

        //Plays audio related to player damage
        public void PlayPlayerDamageAudio(AudioClip clip)
        {
            playerDamageAudio.clip = clip;
            playerDamageAudio.Play ();
        }

        //Plays audio related to building noises
        public void PlayBuildingAudio(AudioClip clip)
        {
            buildingAudio.clip = clip;
            buildingAudio.Play ();
        }

        //Plays audio related to environment noises
        public void PlayItemPickupAudio(AudioClip clip)
        {
            itemPickupAudio.clip = clip;
            itemPickupAudio.Play ();
        }


        //Plays audio related to base
        public void PlayBaseDamageAudio(AudioClip clip)
        {
            baseDamageAudio.clip = clip;
            baseDamageAudio.Play ();
        }

        public void PlayWaveCompleteAudio(AudioClip clip)
        {
            waveCompleteAudio.clip = clip;
            waveCompleteAudio.Play ();
        }

         public void PlayLevelCompleteAudio(AudioClip clip)
        {
            levelCompleteAudio.clip = clip;
            levelCompleteAudio.Play ();
        }
}
