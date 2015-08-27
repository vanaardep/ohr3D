using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerHealth.playerHealth = 10;
		BaseCarHealth.baseCarHealth = 10;
		PlayerGUI.batteryPerc = 100;
		ItemCollection.batteryCount = 0;
		ItemCollection.lightbulbCount = 0;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerHealth.playerHealth == 0 || BaseCarHealth.baseCarHealth == 0)
		{
			Application.LoadLevel("GameOver");
		}
	}
}
