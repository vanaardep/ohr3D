﻿using UnityEngine;
using System.Collections;

public class HoverMenu : MonoBehaviour {

	//public GUISkin gameSkin;

	public Texture2D gui_main;
	public GUIStyle mainFont;

	public Texture2D gui_destroy;
	public Texture2D gui_on;
	public Texture2D gui_upgrade;

	public AudioClip hoverMenuClickSound;
	public AudioClip denyMenuSound;

	//public float menuDistanceFromObj;
	
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

	public bool upgradeShortcut = false;
	private bool AlreadyUpgradedPylon;
	private bool AlreadyUpgradedTurret;
	private bool AlreadyUpgradedMine;

	private bool toggleOnOff = true;

    public AudioClip pylonDestroySound;
    public SoundManagerPylon buzzSound;
   
	void Start()
	{

		thisObj = this.gameObject;
	    h = (Behaviour)GetComponent ("Halo");
		h.enabled = false;
		checkPos = false;
		timer = MenuTimer;
		AlreadyUpgradedPylon = false;
		AlreadyUpgradedTurret = false;
		AlreadyUpgradedMine = false;
		buzzSound = thisObj.GetComponent<SoundManagerPylon>();
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
		SoundManagerMenu.instance.PlayMainMenuClickAudio(hoverMenuClickSound);
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
				//Debug.Log ("Position : "+posy);
				//Debug.Log ("Screen Width : " + Screen.width);
				//Adjusts the y position of the menu if the user clicks on the asset when the asset is placed on the top/Bottom edges of the screen
				 if(posy >= Screen.height -100)
				{
					//Debug.Log ("Check");
					posy = posy -100;
				}
				else if (posy <= 50)
				{
					posy +=20;
					//Debug.Log ("Check2");
				}
			}
			MenuTimer -=Time.deltaTime;
			//Rect rect = new Rect(posx-50, posy-50,200,200);//FOR OPTION2
			//GUI.Box( new Rect(posx-50, posy-50,200,200),"here");//FOR OPTION2
			//GUI.Box(new Rect(posx+10, posy-10,100,100),objName); //after objName there is another parameter you can add to add a layout skin eg objname,"layoutskin"); the " " is NB also can change settings via the GUI.Skin would recommend that
			//Inside GuiSkin (Temp one i created in materials) u can add Custom Styles so choose that
			//if(GUI.Button (new Rect (posx+menuDistanceFromObj, posy + 70,70,20), "Exit") || !rect.Contains(Input.mousePosition))// Option 2 : Buggy code that checks if the mouse is still in range of the object
	      
			// Background
			//GUI.DrawTexture (new Rect (posx+ 10, posy, 100, 120), gui_main, ScaleMode.StretchToFill, true, 0F);
			// Took it out for debugging cause u havent created/assigned a skin yet

			if(thisObj.tag == "Pylon")
			{
				toggleOnOff = GUI.Toggle(new Rect(posx, posy, 60, 60), toggleOnOff, gui_on);

				PylonManager script = thisObj.GetComponent<PylonManager>();
				script.setStatus(toggleOnOff);
				if(toggleOnOff)
				{
					//Debug.Log ("On");
					thisObj.GetComponent<Collider>().isTrigger = false;
					thisObj.GetComponentInChildren<Light>().enabled = true;
					buzzSound.instance.PlayLightpylonBuzz();
				}
				else if(!toggleOnOff)
				{
					//Debug.Log ("Off");
					thisObj.GetComponent<Collider>().isTrigger = true;
					thisObj.GetComponentInChildren<Light>().enabled = false;
					buzzSound.instance.MuteLightpylonBuzz();
				}

			}
			if(GUI.Button (new Rect (posx, posy + 55, 30, 30), gui_upgrade, mainFont))
			{
				if(thisObj.tag == "Pylon")
				{
					if(upgradeShortcut || ItemCollection.lightbulbCount >=2 && !AlreadyUpgradedPylon)
					{
						Vector3 position = thisObj.transform.position;
						Destroy(this.gameObject);
						GameObject thisObject = Instantiate(Resources.Load("pylonAlpha"), position, Quaternion.identity) as GameObject;
						SoundManagerMenu.instance.PlayMainMenuClickAudio(hoverMenuClickSound);
						AlreadyUpgradedPylon = true;
						ItemCollection.lightbulbCount -=2;
					}
					else
					{
						//PUT message dialog or sound to state the user cant upgrade Insufficint Resources
						SoundManagerMenu.instance.PlayMenuDenyAudio(denyMenuSound);
					}
				}
				if(thisObj.tag == "Turret")
				{
					if(upgradeShortcut || ItemCollection.lightbulbCount >=2 && !AlreadyUpgradedTurret)
					{
						Vector3 position = thisObj.transform.position;
						Destroy(this.gameObject);
						GameObject thisObject = Instantiate(Resources.Load("turretAlpha"), position, Quaternion.identity) as GameObject;
						SoundManagerMenu.instance.PlayMainMenuClickAudio(hoverMenuClickSound);
						
						AlreadyUpgradedTurret = true;
						ItemCollection.lightbulbCount -=2;
					}
					else
					{
						//PUT message dialog or sound to state the user cant upgrade Insufficint Resources
						SoundManagerMenu.instance.PlayMenuDenyAudio(denyMenuSound);	
					}
				}
				if(thisObj.tag == "Mine")
				{
					if(upgradeShortcut || ItemCollection.lightbulbCount >=2 && !AlreadyUpgradedMine)
					{
						Vector3 position = thisObj.transform.position;
						Destroy(this.gameObject);
						GameObject thisObject = Instantiate(Resources.Load("lightMineAlpha"), position, Quaternion.identity) as GameObject;
						SoundManagerMenu.instance.PlayMainMenuClickAudio(hoverMenuClickSound);
						AlreadyUpgradedMine = true;
						ItemCollection.lightbulbCount -=1;
					}
					else
					{
						//PUT message dialog or sound to state the user cant upgrade Insufficint Resources
						SoundManagerMenu.instance.PlayMenuDenyAudio(denyMenuSound);
					}
				}
			}
			if(GUI.Button (new Rect (posx + 45, posy + 55, 30, 30), gui_destroy, mainFont))
			{
				SoundManagerMenu.instance.PlayMainMenuClickAudio(hoverMenuClickSound);
				if(thisObj.tag == "Pylon")
				{
				   Destroy(this.gameObject);
                   SoundManager.instance.PlayBuildingAudio(pylonDestroySound);
				   PlayerGUI.batteryPerc +=10;
				}
				else if(thisObj.tag == "Turret")
				{
					Destroy(this.gameObject);
					PlayerGUI.batteryPerc +=5;
				}
				else if(thisObj.tag =="glowStick")
				{
					Destroy (this.gameObject);
					BuildDefenceObject.signalCount++;
				}
				else if(thisObj.tag =="Mine")
				{
					Destroy(this.gameObject);
					PlayerGUI.batteryPerc +=5;
				}

			}
			/*if(GUI.Button (new Rect (posx + 10, posy + 90,70,20), "Exit", mainFont) || MenuTimer <= 0) //Two options  : Option 1 : one that uses a Timer but then the menu is only available for 10 seconds 
			{
				exitBool = true;
				MenuTimer = timer;
				checkPos = false;
			}*/
			if(MenuTimer <= 0) //Two options  : Option 1 : one that uses a Timer but then the menu is only available for 10 seconds 
			{
				exitBool = true;
				MenuTimer = timer;
				checkPos = false;
			}
		}
	}
}
