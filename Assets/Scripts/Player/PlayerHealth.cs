using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public static int playerHealth = 10;
	public AudioClip hurtSound;
	public Animator m_Animator;
	// Use this for initialization
	void Start () {
		playerHealth = 10;
		m_Animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision coll){
        if(coll.gameObject.tag=="Enemy") {
        	if(playerHealth != 0){
    	        playerHealth -= 1;
    	        SoundManager.instance.PlayPlayerDamageAudio(hurtSound); //player getting hurt
        	}
        	else{

        		//GameObject.Destroy("Player");
        	}
    	}
	}

	/*void OnGUI(){
		GUI.Box (new Rect (Screen.width/2 - 300, Screen.height/2 - 150, 120, 40), "Health: " + playerHealth);
	}*/

}
