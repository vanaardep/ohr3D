using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {


    void start()
	{

	}
    void update()
	{

	}
	

	public void ChangeToScene (string scenceToChange) {

		Application.LoadLevel (scenceToChange);
	
	}

	public void loadLvl1()
	{
		Application.LoadLevel ("Level1");
	}
}
