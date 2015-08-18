using UnityEngine;
using System.Collections;

public class glowStick : MonoBehaviour {

	public Light light;

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider other){

		Debug.Log (other.gameObject.tag);
		Debug.Log (other);
		if (other.tag == "Enemy") { //If enemy enter collision radius turn red + increase intensity

			light.intensity = 8;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.name == "enemyCollider") { //When enemy leave, and none are left in radius turn back to green
			light.intensity = 2;

		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
