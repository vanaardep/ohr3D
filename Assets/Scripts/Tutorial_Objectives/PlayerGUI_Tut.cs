using UnityEngine;
using System.Collections;

public class PlayerGUI_Tut : MonoBehaviour {
	
	public static int batteryPerc;
	public Texture2D gui_main;
	public Texture2D gui_hotkeys;
	public Texture2D gui_lightbulbs;
	public Texture2D gui_baseCar;
	public Texture2D gui_health;
	public GUIStyle mainFont;
	public GUIStyle smallFont;
	public GUIStyle dialogFont;
	
	public string imageFolderName = "Health circle pieces";
	//public ArrayList pictures = new ArrayList();
	public Texture2D[] textures;

	public bool showGUI = false;
	string bottomText;

	bool pulseHealth = false;
	bool pulseLightBulbs = false;
	bool pulseBaseCar = false;
	bool pulseHotkeys = false;

	float dialogTimer;
	float elapsedTimer;
	bool setElapsedTime = false;
	
	// Use this for initialization
	void Start () {
		batteryPerc = 100;
		
		textures = System.Array.ConvertAll(Resources.LoadAll(imageFolderName, typeof(Texture2D)),o=>(Texture2D)o);
	}
	
	// Update is called once per frame
	void Update () {
		dialogTimer = Time.time - elapsedTimer;
	}
	
	void OnGUI(){

		if (showGUI) {

			// Draw labels
			if (dialogTimer < 5) {
				bottomText = "This is your remaining player health and battery percentage.";
				pulseHealth = true;
			} else if (dialogTimer < 10) {
				bottomText = "This is the number of upgrade light bulbs you have collected.";
				pulseHealth = false;
				pulseLightBulbs = true;
			} else if (dialogTimer < 15) {
				bottomText = "This is the remaining base car health.";
				pulseLightBulbs = false;
				pulseBaseCar = true;
			} else if (dialogTimer < 20) {
				bottomText = "These are your hotkeys to place weapons and defences.";
				pulseBaseCar = false;
				pulseHotkeys = true;
			} else if (dialogTimer < 25) {
				bottomText = "";
				// End tutorial
				GameObject theOwner = GameObject.Find("GUITutorial");
				GUITut_Objectives script = theOwner.GetComponent<GUITut_Objectives>();
				script.endTutorial();
			}

			GUI.Label (new Rect (30, 30, Screen.width - 60, 70), bottomText, dialogFont);

			// Set elapsed time
			if (!setElapsedTime) {
				setElapsedTime = true;
				elapsedTimer = Time.time;
			}

			float alpha = Mathf.PingPong (Time.time, 1);

			// Start main pulse
			if (pulseHealth)
				GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);

				// Main circle
				GUI.DrawTexture (new Rect (20, 20, 150, 150), gui_main, ScaleMode.ScaleToFit, true, 0F);
				GUI.Label (new Rect (50, 50, 100, 100), batteryPerc + "%", mainFont);
		
				// Health bar
				gui_health = textures [PlayerHealth.playerHealth - 1];
				GUI.DrawTexture (new Rect (22.5f, 22, 145, 145), gui_health, ScaleMode.ScaleToFit, true, 0F);
			
			// Reset pulse
			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, 1);
			// Start lightbulb pulse
			if (pulseLightBulbs)
				GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);

				// Lightbulbs
				GUI.DrawTexture (new Rect (170, 20, 50, 50), gui_lightbulbs, ScaleMode.ScaleToFit, true, 0F);
				GUI.Label (new Rect (170, 30, 50, 50), ItemCollection.lightbulbCount + "/10", smallFont);

			// Reset pulse
			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, 1);
			// Start baseCar pulse
			if (pulseBaseCar)
				GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);

				// BaseCar
				GUI.DrawTexture (new Rect (230, 20, 50, 50), gui_baseCar, ScaleMode.ScaleToFit, true, 0F);
				GUI.Label (new Rect (230, 30, 50, 50), BaseCarHealth.baseCarHealth + "/10", smallFont);

			// Reset pulse
			GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, 1);
			// Start hotkey pulse
			if (pulseHotkeys)
				GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);

				// Hotkeys
			GUI.DrawTexture(new Rect(Screen.width / 2 - 115, Screen.height - 55, 230, 55), gui_hotkeys, ScaleMode.StretchToFill, true, 0F);
		}
	}
}

