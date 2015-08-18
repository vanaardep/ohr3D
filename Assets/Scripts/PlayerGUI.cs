using UnityEngine;
using System.Collections;

public class PlayerGUI : MonoBehaviour {

	public static int batteryPerc;
	public Texture2D gui_main;
	public Texture2D gui_hotkeys;
	public Texture2D gui_lightbulbs;
	public Texture2D gui_baseCar;
	public GUIStyle mainFont;
	public GUIStyle smallFont;

	// Use this for initialization
	void Start () {
		batteryPerc = 100;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		//GUI.Box (new Rect (Screen.width/2 - 290, Screen.height/2 - 150, 120, 50), "Battery : " + batteryPerc+"%" + "\n" + "Health : " + PlayerHealth.playerHealth + "\n" + "Base Health: " + BaseCarHealth.baseCarHealth);

		// Main circle
		GUI.DrawTexture(new Rect(20, 20, 150, 150), gui_main, ScaleMode.ScaleToFit, true, 0F);
		GUI.Label(new Rect(50, 50, 100, 100), batteryPerc+"%", mainFont);

		// Hotkeys
		GUI.DrawTexture(new Rect(Screen.width / 2 - 150, Screen.height - 60, 250, 55), gui_hotkeys, ScaleMode.StretchToFill, true, 0F);

		// Lightbulbs
		GUI.DrawTexture(new Rect(170, 20, 50, 50), gui_lightbulbs, ScaleMode.ScaleToFit, true, 0F);
		GUI.Label(new Rect(170, 30, 50, 50), ItemCollection.lightbulbCount + "/10", smallFont);

		// BaseCar
		GUI.DrawTexture(new Rect(230, 20, 50, 50), gui_baseCar, ScaleMode.ScaleToFit, true, 0F);
		GUI.Label(new Rect(230, 30, 50, 50), BaseCarHealth.baseCarHealth + "/10", smallFont);
	}
}
