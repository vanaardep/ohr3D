using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {


	
	// Update is called once per frame
	public void ChangeToScene (string scenceToChange) {

		Application.LoadLevel (scenceToChange);
	
	}
}
