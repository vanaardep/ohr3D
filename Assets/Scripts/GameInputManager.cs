using UnityEngine;
using System.Collections;

public class GameInputManager : MonoBehaviour {
    public static KeyCode pylonKey;
    public static KeyCode turretKey;
    public static KeyCode mineKey;
    public static KeyCode teslaKey;

    //CHEATS 
    public static KeyCode lvl1;
    public static KeyCode lvl2;
    public static KeyCode lvl3;
    public static KeyCode MaxLightBulbs;
    public static KeyCode MaxBattery;
    // Use this for initialization
    void Start () {
    pylonKey = KeyCode.E;
    turretKey = KeyCode.R;
    mineKey = KeyCode.Q;
    teslaKey = KeyCode.Mouse1;
        lvl1 = KeyCode.Alpha1;
        lvl2 = KeyCode.Alpha2;
        lvl3 = KeyCode.Alpha3;
        MaxLightBulbs = KeyCode.Alpha4;
        MaxBattery = KeyCode.Alpha5;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(lvl1))
        {
            Application.LoadLevel("Level1");
        }
        if (Input.GetKeyDown(lvl2))
        {
            Application.LoadLevel("Level2");
        }
        if (Input.GetKeyDown(lvl3))
        {
            Application.LoadLevel("Level3");
        }

        if (Input.GetKeyDown(MaxLightBulbs))
        {
            ItemCollection.lightbulbCount = 500;
        }

        if (Input.GetKeyDown(MaxBattery))
        {
            PlayerGUI.batteryPerc = 500;
        }
    }
}
