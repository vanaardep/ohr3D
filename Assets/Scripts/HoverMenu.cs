using UnityEngine;
using System.Collections;

public class HoverMenu : MonoBehaviour {

	//public GUISkin gameSkin;

	public Texture2D gui_main;
	public GUIStyle mainFont;

	public float menuDistanceFromObj;
	
	public string objName;
	private bool displayObjName = false;
	GameObject thisObj;
	private Behaviour h;
	private bool exitBool;
	private float posx;
	private float posy;
	public float MenuTimer;
	private float timer;
	private bool checkPos;

	private bool toggleOnOff = true;

	void Start()
	{
		thisObj = this.gameObject;
	    h = (Behaviour)GetComponent ("Halo");
		h.enabled = false;
		checkPos = false;
		timer = MenuTimer;
	}
	void OnGUI()
	{
		//GUI.skin = gameSkin;
		displayMenu();
	}

	void Update()
	{
		if (exitBool)
		{
			displayObjName = false;
			h.enabled = false;
		}

	}

	void OnMouseDown()
	{
		h.enabled = true;
		displayObjName = true; 
		exitBool = false;
	}

	public void displayMenu()
	{

		if (displayObjName) 
		{ 
			if(!checkPos)
			{
				posx = Event.current.mousePosition.x;
				posy = Event.current.mousePosition.y;
				checkPos = true;
			}
			MenuTimer -=Time.deltaTime;
			//Rect rect = new Rect(posx-50, posy-50,200,200);//FOR OPTION2
			//GUI.Box( new Rect(posx-50, posy-50,200,200),"here");//FOR OPTION2
			//GUI.Box(new Rect(posx+menuDistanceFromObj, posy-10,100,100),objName); //after objName there is another parameter you can add to add a layout skin eg objname,"layoutskin"); the " " is NB also can change settings via the GUI.Skin would recommend that
			//Inside GuiSkin (Temp one i created in materials) u can add Custom Styles so choose that
			//if(GUI.Button (new Rect (posx+menuDistanceFromObj, posy + 70,70,20), "Exit") || !rect.Contains(Input.mousePosition))// Option 2 : Buggy code that checks if the mouse is still in range of the object
	      
			// Background
			GUI.DrawTexture (new Rect (posx, posy, 100, 120), gui_main, ScaleMode.StretchToFill, true, 0F);


			if(thisObj.tag == "Pylon")
			{
				toggleOnOff = GUI.Toggle(new Rect(posx + 20, posy + 10, 80, 20), toggleOnOff, "On/Off");

				PylonManager script = thisObj.GetComponent<PylonManager>();
				script.setStatus(toggleOnOff);
				if(toggleOnOff)
				{
					//Debug.Log ("On");
					thisObj.GetComponent<Collider>().isTrigger = false;
					thisObj.GetComponentInChildren<Light>().enabled = true;
				
				}
				else if(!toggleOnOff)
				{
					//Debug.Log ("Off");
					thisObj.GetComponent<Collider>().isTrigger = true;
					thisObj.GetComponentInChildren<Light>().enabled = false;
				}

			}
			if(GUI.Button (new Rect (posx + 15, posy + 40,70,20), "Upgrade", mainFont))
			{

			}
			if(GUI.Button (new Rect (posx + 15, posy + 65,70,20), "Destroy", mainFont))
			{
				if(thisObj.tag == "Pylon")
				{
				   Destroy(this.gameObject);
				   PlayerGUI.batteryPerc +=10;
				}
				else if(thisObj.tag == "Turret")
				{
					Destroy(this.gameObject);
					PlayerGUI.batteryPerc +=5;
				}

			}
			Debug.Log ("Menu Timer : " + MenuTimer);
			if(GUI.Button (new Rect (posx + 15, posy + 90,70,20), "Exit", mainFont) || MenuTimer <= 0) //Two options  : Option 1 : one that uses a Timer but then the menu is only available for 10 seconds 
			{
				exitBool = true;
				MenuTimer = timer;
				checkPos = false;
			}
		}
	}
}
