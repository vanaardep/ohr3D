using UnityEngine;
using System.Collections;

public class AutoRestart : MonoBehaviour {
	public float timer = 0f;
	// Use this for initialization
	void Start () {
		timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("update");
		timer += Time.deltaTime;
		if (timer > 15) {
			//Debug.Log("In");
			Application.LoadLevel ("Level1");
		}
	}
}
