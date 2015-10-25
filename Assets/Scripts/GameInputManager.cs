using UnityEngine;
using System.Collections;

public class GameInputManager : MonoBehaviour {
    public KeyCode pylonKey;
    public KeyCode turretKey;
    public KeyCode mineKey;
    public KeyCode teslaKey;
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
