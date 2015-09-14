using UnityEngine;
using System.Collections;

public class PylonManager : MonoBehaviour {
	public float pylonUsageDelay = 5;
	public bool onStatus = true;

	// Use this for initialization
	void Start () {
		//status = true;
		//Debug.Log("HERE NAME : "+ this.gameObject.tag);
		pylonUsageDelay = 5;
	}

	/*public void setStatus(bool Getstatus)
	{
		onStatus = Getstatus;
		//Debug.Log("INSIDE SET STATUS" + status);
		pylonUsageDelay = 5;
	}*/
	
	// Update is called once per frame
	void Update () {
		Debug.Log(">" + onStatus);

		if (onStatus) {
			//Debug.Log ("INSIDE status");
			pylonUsageDelay -= Time.deltaTime;
			if (pylonUsageDelay < 0 && PlayerGUI.batteryPerc != 0) {
				Debug.Log ("INSIDE DEC");
				PlayerGUI.batteryPerc --;
				pylonUsageDelay = 5;
			}

			if (PlayerGUI.batteryPerc <= 0) {
				Destroy (gameObject);
			}
		}
	
	}
}
