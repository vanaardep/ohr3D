using UnityEngine;
using System.Collections;
using UnityEditor;

public class ControlMenuHandler : MonoBehaviour
{
    public Texture2D menu_background;
    public GUIStyle mainFont;
    public GUIStyle secondaryFont;
	public GUIStyle secondaryFontGrey;
    public GUIStyle smallText;

    private bool changePylon = false;
    private bool changeMine = false;
    private bool changeTurret = false;
    private bool changeShoot = false;
    private bool showError = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), menu_background, ScaleMode.ScaleAndCrop, true, 0F);

		if (GUI.Button(new Rect(50, Screen.height - 60, 100, 50), "BACK", secondaryFont))
        {
            Application.LoadLevel("Menu");
        }
        if (GUI.Button(new Rect(Screen.width - 180, Screen.height - 50, 100, 50), "RESET TO DEFAULTS", smallText))
        {
            GameInputManager.mineKey = KeyCode.Q;
            GameInputManager.teslaKey = KeyCode.Mouse1;
            GameInputManager.pylonKey = KeyCode.E;
            GameInputManager.turretKey = KeyCode.R;
            //Application.LoadLevel("Menu");
        }
		GUI.Label(new Rect(50, 20, 100, 40), "CONTROLS", mainFont);
        GUI.Label(new Rect(50, 100, 100, 40), "Place Pylon", secondaryFont);
		GUI.Label(new Rect(50, 150, 100, 40), "Place Turret", secondaryFont);
		GUI.Label(new Rect(50, 200, 100, 40), "Place Mine", secondaryFont);
		GUI.Label(new Rect(50, 250, 100, 40), "Shoot", secondaryFont);

		if (GUI.Button(new Rect(220, 100, 50, 40), GameInputManager.pylonKey.ToString(), secondaryFontGrey))
        {
            changePylon = true;

        }
		if (GUI.Button(new Rect(220, 150, 50, 40), GameInputManager.turretKey.ToString(), secondaryFontGrey))
        {
            changeTurret = true;
        }
		if (GUI.Button(new Rect(220, 200, 50, 40), GameInputManager.mineKey.ToString(), secondaryFontGrey))
        {
            changeMine = true;
        }

        string rightMouse = GameInputManager.teslaKey.ToString();
        if (rightMouse.Equals("Mouse1"))
        {
            rightMouse = "RMB";
        }
		if (GUI.Button(new Rect(220, 250, 250, 40), rightMouse, secondaryFontGrey))
        {
            changeShoot = true;
        }
        //****************************
		// Change controls

        if (changePylon)
        {
            GUI.Window(0, new Rect((Screen.width / 2) - 150, 50, 300, 300), ShowGUI, "Press key for Build Pylon...", secondaryFontGrey);
            GUI.FocusWindow(0);
        }
        if (changeMine)
        {
			GUI.Window(1, new Rect((Screen.width / 2) - 150, 50, 300, 300), ShowGUI, "Press key for Build Mine...", secondaryFontGrey);
            GUI.FocusWindow(1);
        }
        if (changeShoot)
        {
			GUI.Window(2, new Rect((Screen.width / 2) - 150, 50, 300, 300), ShowGUI, "Press key for Shooting...", secondaryFontGrey);
            GUI.FocusWindow(2);
        }
        if (changeTurret)
        {
			GUI.Window(3, new Rect((Screen.width / 2) - 150, 50, 300, 300), ShowGUI, "Press key for Build Turret...", secondaryFontGrey);
            GUI.FocusWindow(3);
        }
    }

    void ShowGUI(int windowID)
    {
        /*string currentControl = "";
       
        switch (windowID)
        {
            case 0:
                currentControl = "Build Pylon";

                break;
            case 1:
                currentControl = "Build Mine";
                break;
            case 2:
                currentControl = "Change Shooting Button";
                break;
            case 3:
                currentControl = "Build Turret";
                break;
        }

        GUI.Label(new Rect(65, 40, 200, 30), "Press key for " + currentControl + " ", smallText);*/

        Event e = Event.current;
        if (e.isKey)
        {

            switch (windowID)
            {
                case 0:
                    GameInputManager.pylonKey = e.keyCode;
                    changePylon = false;
                    break;
                case 1:
                    GameInputManager.mineKey = e.keyCode;
                    changeMine = false;
                    break;
                case 2:
                    GameInputManager.teslaKey = e.keyCode;
                    changeShoot = false;
                    break;
                case 3:
                    GameInputManager.turretKey = e.keyCode;
                    changeTurret = false;
                    break;
            }
        }
    }
}
