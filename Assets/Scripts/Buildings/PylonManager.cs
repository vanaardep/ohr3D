﻿using UnityEngine;
using System.Collections;

public class PylonManager : MonoBehaviour {
	public float pylonUsageDelay = 2f;
	public bool status = true;

	// Use this for initialization
	void Start () {
		status = true;
		pylonUsageDelay = 2;
	}

	public void setStatus(bool _status)
	{
		status = _status;
		pylonUsageDelay = 2;
	}
	
	// Update is called once per frame
	void Update () {
		if (status) {
			//Debug.Log ("INSIDE status");
			pylonUsageDelay -= Time.deltaTime;
			if (pylonUsageDelay < 0 && PlayerGUI.batteryPerc != 0) {
				//Debug.Log ("INSIDE DEC");
				PlayerGUI.batteryPerc --;
				pylonUsageDelay = 2;
			}

			if (PlayerGUI.batteryPerc <= 0) {
				Destroy (gameObject);
			}
		}
	
	}
}
