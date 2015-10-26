using UnityEngine;
using System.Collections;

public class GameInputManager : MonoBehaviour {
    public static KeyCode pylonKey;
    public static KeyCode turretKey;
    public static KeyCode mineKey;
    public static KeyCode teslaKey;
    // Use this for initialization
    void Start () {
    pylonKey = KeyCode.E;
    turretKey = KeyCode.R;
    mineKey = KeyCode.Q;
    teslaKey = KeyCode.Mouse1;
}
	
	// Update is called once per frame
	void Update () {
	
	}
}
