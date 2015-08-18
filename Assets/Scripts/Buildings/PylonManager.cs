using UnityEngine;
using System.Collections;

public class PylonManager : MonoBehaviour {
	public float pylonUsageDelay = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		pylonUsageDelay -= Time.deltaTime;
		if (pylonUsageDelay < 0 && PlayerGUI.batteryPerc!=0) {
			PlayerGUI.batteryPerc --;
			pylonUsageDelay = 5;
		}

		if (PlayerGUI.batteryPerc <= 0) {
			Destroy (gameObject);
		}
	
	}
}
