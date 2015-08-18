using UnityEngine;
using System.Collections;
			
public class ItemCollection : MonoBehaviour {

	public static int maxAmountOfLightMines = 5; // Amount of light mines aloud

	public static int batteryCount = 0;
	public static int lightbulbCount = 0;
	public static int lightMineCount = 0;
	public AudioClip pickupSound;

	// Use this for initialization
	void Start () {
		batteryCount = 0;
		lightbulbCount = 0;	
	}
	
	// Update is called once per frame
	void Update () {

	}

	//Increment battery count and remove battery from the game
	void OnTriggerEnter(Collider other) { 

		if (other.tag == "BatteryCollider") { 
			batteryCount += 1;
			PlayerGUI.batteryPerc +=20;
			SoundManager.instance.PlaySingle(pickupSound);
			Destroy(other.gameObject); //destroys the sprite's collider
			Debug.Log("Player touched Battery");
			Debug.Log (batteryCount);

		} else if (other.tag == "LightbulbCollider") { 
			lightbulbCount += 1;
			SoundManager.instance.PlaySingle(pickupSound);
			Destroy(other.gameObject); //destroys the sprite's collider
			Debug.Log("Player touched Battery");
			Debug.Log (batteryCount);

		}
	}

	void OnGUI(){
		GUI.Box (new Rect (0, 0, 100, 40), "Batteries: " + batteryCount);
		GUI.Box (new Rect (0, 50, 100, 40), "Lightbulbs: " + lightbulbCount);
	}
}