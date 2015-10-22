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
    private bool played = false;
	// Use this for initialization
	void Start () {
		resetValue = mineExplosionDelay;
		 minePosition = gameObject.transform.position ;
		//currentEnemies = GameObject.FindObjectOfType (typeof(EnemyMove)) as EnemyMove;
	}
	
	// Update is called once per frame
	void Update () {
		if (timerActivated) {
			mineExplosionDelay -= Time.deltaTime;
		
			if (mineExplosionDelay <= 0.5f) {
				timeToExplode = true;
			}
			Debug.Log(mineExplosionDelay);
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy" && played == false) {
            played = true;
			timerActivated = true;
			tempPs = Instantiate(ps, new Vector3(minePosition.x, minePosition.y +1, minePosition.z), Quaternion.identity) as ParticleSystem;
			tempPs.Play();
            Debug.Log(tempPs.duration + "Ps duration");
			Destroy(tempPs,tempPs.duration);

			}
	}
	
	void OnTriggerStay(Collider other) {
		//Debug.Log (other.tag);
		if (timeToExplode == true && other.tag == "Enemy") {
			//Destroy(other.gameObject);
		
			((EnemyMove)other.gameObject.GetComponent(typeof(EnemyMove))).killGhoul();


			//other.gameObject.killGhoul();
			Destroy(gameObject);
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
