using UnityEngine;
using System.Collections;

public class LightTurretAttack : MonoBehaviour {

 	private float fireStart = 0f;
 	private float fireCooldown = 0.5f; // 0.5 seconds of active

	void Start () {
	
	}
	
	void Update () {

		if(Time.time > fireStart + fireCooldown) {
			this.GetComponentInChildren<Light> ().intensity = 0;
		}
	}

	void OnCollisionStay (Collision col) {
        if((col.gameObject.tag == "Enemy")) {
     			fireStart = Time.time;
	   			Debug.Log("LIGHTTURRET ATTACKKKKKKKKKKKKKKKK");
	            Destroy(col.gameObject);
	    }
        
        else {
         	this.GetComponentInChildren<Light> ().intensity = 8;
        }
         
    }
		
}
