using UnityEngine;
using System.Collections;

public class LightTurretAttack : MonoBehaviour {

 	private float fireStart = 0f;
 	private float fireCooldown = 5f; // 5cd of turret

 	private float fireAnimStart = 0f;
 	private float fireAnimCooldown = 1f; // 1 second light pulse animation

	void Start () {
	
	}
	
	void Update () {

		if(Time.time > fireAnimStart + fireAnimCooldown) {
        		fireAnimStart = Time.time;
         		this.GetComponentInChildren<Light> ().intensity = 0;
         }
	}

	void OnCollisionStay (Collision col) {
        if((col.gameObject.tag == "Enemy") && (Time.time > fireStart + fireCooldown)) {
     			fireStart = Time.time;
	   			Debug.Log("LIGHTTURRET ATTACKKKKKKKKKKKKKKKK");
	            Destroy(col.gameObject);
	            this.GetComponentInChildren<Light> ().intensity = 8;
	    }
         
    }
		
}
