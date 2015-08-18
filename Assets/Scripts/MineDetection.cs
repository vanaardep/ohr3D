using UnityEngine;
using System.Collections;

public class MineDetection : MonoBehaviour {
	private bool timeToExplode = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other) {
		timeToExplode = true;
		
	}
	
	void OnTriggerStay(Collider other) {
		Debug.Log (other.tag);
		if (timeToExplode == true && other.tag == "Enemy") {
			Destroy(other.gameObject);
			PlayerGUI.batteryPerc+=5; // Everytime a mine kills an enemy gets +5 battery
			Destroy(gameObject);
		}
		
	}
}
