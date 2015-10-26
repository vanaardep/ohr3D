using UnityEngine;
using System.Collections;

public class ControlMenuHandler : MonoBehaviour {
    public Texture2D menu_background;
    public GUIStyle mainFont;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI(){
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), menu_background, ScaleMode.ScaleAndCrop, true, 0F);

    }
}
