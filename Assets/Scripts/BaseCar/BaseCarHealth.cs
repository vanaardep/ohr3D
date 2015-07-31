using UnityEngine;
using System.Collections;

public class BaseCarHealth : MonoBehaviour {

	public static int baseCarHealth = 10;

	// Use this for initialization
	void Start () {
		baseCarHealth = 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// If base car collides with another collider minus its health if the collider is the Enemy class
	void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag=="Enemy") {
        	if(baseCarHealth != 0){
    	        baseCarHealth -= 1;
        	}
        	else{
        		//Base car needs to die here
        	}
    	}
	}

	void OnGUI(){
		GUI.Box (new Rect (Screen.width/2 - 400, Screen.height/2 - 80, 120, 40), "Base Health: " + baseCarHealth);
	}

}
