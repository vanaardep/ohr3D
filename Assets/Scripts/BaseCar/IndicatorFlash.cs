using UnityEngine;
using System.Collections;

public class IndicatorFlash : MonoBehaviour {

	Light lightInd;
	bool lightOn = true;

	// Use this for initialization
	void Start () {
		lightInd = GetComponent<Light>();
		InvokeRepeating ("toggleLight", 0, 0.5F);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void toggleLight () {
		Debug.Log ("CALL");
		if (lightOn) {
			lightInd.enabled = false;
			lightOn = false;
		} else {
			lightInd.enabled = true;
			lightOn = true;
		}
	}
}
