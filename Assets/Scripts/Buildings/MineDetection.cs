using UnityEngine;
using System.Collections;

public class MineDetection : MonoBehaviour {







	public ParticleSystem ps;


	private Vector3 minePosition;
	private bool timeToExplode = false;
	public float mineExplosionDelay;
	private bool timerActivated = false;
	private float resetValue; //If script needs to be reset
	private ParticleSystem tempPs; // temporaryParticleSystem
	// Use this for initialization
	void Start () {
		resetValue = mineExplosionDelay;
		 minePosition = gameObject.transform.position ;
	}
	
	// Update is called once per frame
	void Update () {
		if (timerActivated) {
			mineExplosionDelay -= Time.deltaTime;
		
			if (mineExplosionDelay <= 0.0f) {
				timeToExplode = true;
			}
			Debug.Log(mineExplosionDelay);
		}
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy") {
			timerActivated = true;
			tempPs = Instantiate(ps, new Vector3(minePosition.x, minePosition.y +1, minePosition.z), Quaternion.identity) as ParticleSystem;
			tempPs.Play();
			Destroy(tempPs,tempPs.duration);
			}
	}
	
	void OnTriggerStay(Collider other) {
		//Debug.Log (other.tag);
		if (timeToExplode == true && other.tag == "Enemy") {
			Destroy(other.gameObject);
			Destroy(gameObject);
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
