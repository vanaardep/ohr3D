using UnityEngine;
using System.Collections;

public class lightMineManager : MonoBehaviour {
	private bool timeToExplode = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		//Debug.Log ("Leeeeeeerrrooyyy Jenkins!");
		timeToExplode = true;

	}

	void OnTriggerStay(Collider other) {
		//Debug.Log ("Leeeeeeerrrooyyy Jenkins!");
		Debug.Log (other.tag);
		if (timeToExplode == true && other.tag == "Enemy") {
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
		
	}
}
