using UnityEngine;
using System.Collections;
//using UnityEditor;

public class ControlMenuHandler : MonoBehaviour
{
    public Texture2D menu_background;
    public GUIStyle mainFont;
    public GUIStyle secondaryFont;
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

        if (GUI.Button(new Rect(Screen.width - 120, Screen.height - 120, 100, 50), "BACK", mainFont))
        {
            Application.LoadLevel("Menu");
        }
        if (GUI.Button(new Rect(Screen.width - 200, Screen.height - 180, 100, 50), "BACK AND SET TO DEFAULTS", smallText))
        {
            GameInputManager.mineKey = KeyCode.Q;
            GameInputManager.teslaKey = KeyCode.Mouse1;
            GameInputManager.pylonKey = KeyCode.E;
            GameInputManager.turretKey = KeyCode.R;
            Application.LoadLevel("Menu");
        }
        GUI.Label(new Rect(100, 100, 100, 40), "Place Pylon :", secondaryFont);
        GUI.Label(new Rect(100, 200, 100, 40), "Place Turret :", secondaryFont);
        GUI.Label(new Rect(100, 300, 100, 40), "Place Mine :", secondaryFont);
        GUI.Label(new Rect(100, 400, 100, 40), "Shoot :", secondaryFont);

        if (GUI.Button(new Rect(300, 100, 50, 40), GameInputManager.pylonKey.ToString(), secondaryFont))
        {
            changePylon = true;

        }
        if (GUI.Button(new Rect(300, 200, 50, 40), GameInputManager.turretKey.ToString(), secondaryFont))
        {
            changeTurret = true;
        }
        if (GUI.Button(new Rect(300, 300, 50, 40), GameInputManager.mineKey.ToString(), secondaryFont))
        {
            changeMine = true;
        }

        string rightMouse = GameInputManager.teslaKey.ToString();
        if (rightMouse.Equals("Mouse1"))
        {
            rightMouse = "Right Mouse Button";
        }
        if (GUI.Button(new Rect(300, 400, 250, 40), rightMouse, secondaryFont))
        {
            changeShoot = true;
        }
        //****************************
        if (changePylon)
        {
            GUI.Window(0, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
            , 300, 300), ShowGUI, "Change Control");
            GUI.FocusWindow(0);
        }
        if (changeMine)
        {
            GUI.Window(1, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75, 300, 300), ShowGUI, "Change Control");
            GUI.FocusWindow(1);
        }
        if (changeShoot)
        {
            GUI.Window(2, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
            , 300, 300), ShowGUI, "Change Control");
            GUI.FocusWindow(2);
        }
        if (changeTurret)
        {
            GUI.Window(3, new Rect((Screen.width / 2) - 150, (Screen.height / 2) - 75
            , 300, 300), ShowGUI, "Change Control");
            GUI.FocusWindow(3);

        }


    }

    void ShowGUI(int windowID)
    {
        string currentControl = "";
        // int currentActiveBool = -1 ;
        Debug.Log(windowID);
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

        GUI.Label(new Rect(65, 40, 200, 30), "Enter Key to : " + currentControl + " ", smallText);


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

        //changePylon = false;



    }

}
