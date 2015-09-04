using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Animator m_Animator;
	public GameObject auron;
	// Use this for initialization
	void Start () {
		PlayerHealth.playerHealth = 10;
		BaseCarHealth.baseCarHealth = 10;
		PlayerGUI.batteryPerc = 100;
		ItemCollection.batteryCount = 0;
		ItemCollection.lightbulbCount = 0;
		m_Animator = auron.GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerHealth.playerHealth == 0 || BaseCarHealth.baseCarHealth == 0)
		{
			if(PlayerHealth.playerHealth == 0){
				auron.GetComponent<Rigidbody> ().Sleep ();
			
				m_Animator.SetBool("Dead",true);
				Invoke("callGameOver",5f);
			}


		}
	}

	void callGameOver(){
		Application.LoadLevel("GameOver");
	}
}
