using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {
	public float timer = 0f;

    void start()
	{
		timer = 0;
	}
    void update()
	{
		Debug.Log ("update");
		timer += Time.deltaTime;
		if (timer > 10) {
			Debug.Log("In");
			Application.LoadLevel ("Level1");
		}
	}
	
	// Update is called once per frame
	public void ChangeToScene (string scenceToChange) {

		Application.LoadLevel (scenceToChange);
	
	}
}
