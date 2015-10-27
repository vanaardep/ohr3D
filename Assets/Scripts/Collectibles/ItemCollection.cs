using UnityEngine;
using System.Collections;
			
public class ItemCollection : MonoBehaviour {

	public static int maxAmountOfLightMines = 5; // Amount of light mines aloud

	public static int batteryCount = 0;
	public static int lightbulbCount = 0;
	public static int lightMineCount = 0;
	public AudioClip pickupSound;

	public GUIStyle mainFont;
	Transform player;
	bool showBatteryCollected = false;
	bool showLightbulbCollected = false;

	// Use this for initialization
	void Start () {
		batteryCount = 0;
		lightbulbCount = 0;	
	}
	
	// Update is called once per frame
	void Update () {

	}

	//Increment battery count and remove battery from the game
	void OnCollisionEnter (Collision col)
    {
		player = GameObject.Find ("Auron").transform;

		if (col.gameObject.tag == "BatteryCollider") { 
			batteryCount += 1;
			PlayerGUI.batteryPerc +=20;
			SoundManager.instance.PlayItemPickupAudio(pickupSound);
			Destroy(col.gameObject); //destroys the sprite's collider
			Debug.Log("Player touched Battery");
			Debug.Log (batteryCount);

			showBatteryCollected = true;
			Invoke ("removeItemCollected", 2);

		} else if (col.gameObject.tag  == "LightbulbCollider") { 
			lightbulbCount += 1;
			SoundManager.instance.PlayItemPickupAudio(pickupSound);
			Destroy(col.gameObject); //destroys the sprite's collider
			Debug.Log("Player touched Battery");
			Debug.Log (batteryCount);

			showLightbulbCollected = true;
			Invoke ("removeItemCollected", 2);
		}
	}

	void removeItemCollected () {
		showBatteryCollected = false;
		showLightbulbCollected = false;
	}

	void OnGUI(){

		string text = "";

		if (showBatteryCollected) {
			text = "+20%";
		} 
		if (showLightbulbCollected) {
			text = "+1";
		}

		if (showBatteryCollected || showLightbulbCollected) {
			Vector3 screenPos = Camera.main.WorldToScreenPoint (player.position);
			GUI.Label (new Rect (screenPos.x - 10, (Screen.height - screenPos.y) - 70, 100, 100), text, mainFont);
		}
	}
}