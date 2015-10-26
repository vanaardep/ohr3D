using UnityEngine;
using System.Collections;

public class MineDetection : MonoBehaviour {



	public ParticleSystem ps;
	public EnemyMove currentEnemies;
	//m_someOtherScriptOnAnotherGameObject = GameObject.FindObjectOfType(typeof(ScriptA)) as ScriptA;
	//m_someOtherScriptOnAnotherGameObject.Test();

	private Vector3 minePosition;
	private bool timeToExplode = false;
	public float mineExplosionDelay;
	private bool timerActivated = false;
	private float resetValue; //If script needs to be reset
	private ParticleSystem tempPs; // temporaryParticleSystem
    public MeshRenderer rend;
    public Light redSpot;

    public AudioSource explosionAudioSource;
    public AudioClip mineExplosionClip;
    private bool played = false;
	// Use this for initialization
	void Start () {
		resetValue = mineExplosionDelay;
		 minePosition = gameObject.transform.position ;
        explosionAudioSource = GetComponent<AudioSource>();
        rend = GetComponent<MeshRenderer>();
        //currentEnemies = GameObject.FindObjectOfType (typeof(EnemyMove)) as EnemyMove;
    }
	
	// Update is called once per frame
	void Update () {
		if (timerActivated) {
			mineExplosionDelay -= Time.deltaTime;
		
			if (mineExplosionDelay <= 0.5f) {
				timeToExplode = true;
			}
			//Debug.Log(mineExplosionDelay);
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy" && played == false) {
            played = true;
			timerActivated = true;
			tempPs = Instantiate(ps, new Vector3(minePosition.x, minePosition.y +1, minePosition.z), Quaternion.identity) as ParticleSystem;
			tempPs.Play();
            explosionAudioSource.PlayOneShot(mineExplosionClip);
            rend.enabled = false; //Hide from view while audio clip plays
            redSpot.enabled = false; //also hide light
            //Debug.Log(tempPs.duration + "Ps duration");
			Destroy(tempPs,tempPs.duration);

			}
	}
	
	void OnTriggerStay(Collider other) {
		//Debug.Log (other.tag);
		if (timeToExplode == true && other.tag == "Enemy") {
			//Destroy(other.gameObject);
		
			((EnemyMove)other.gameObject.GetComponent(typeof(EnemyMove))).killGhoul();


			//other.gameObject.killGhoul();
			Destroy(gameObject,mineExplosionClip.length - 2.2f);
			EnemyManager.enemyKillCount--;
			PlayerGUI.batteryPerc+=5; // Everytime a mine kills an enemy gets +5 battery


		}
		
	}

	void OnTriggerExit(Collider other){ 
		if (other.tag == "Enemy") {
			//Destroy(tempPs);
			mineExplosionDelay = resetValue;
			timeToExplode = false;
			timerActivated = false;
		}
	}


}
