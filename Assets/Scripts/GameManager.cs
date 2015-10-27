using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
	public Animator m_Animator;
	public GameObject auron;

    private bool GameOverFlag;

    public GUIStyle mainFont;
    // Use this for initialization
    void Start () {
		PlayerHealth.playerHealth = 10;
		BaseCarHealth.baseCarHealth = 10;
        GameOverFlag = false;
		PlayerGUI.batteryPerc = 100;
		ItemCollection.batteryCount = 0;
		ItemCollection.lightbulbCount = 0;
		m_Animator = auron.GetComponent<Animator>();
	
		// Set the loaded level name
		PlayerPrefs.SetString("LoadedLevel", Application.loadedLevelName);		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerHealth.playerHealth == 0 || BaseCarHealth.baseCarHealth == 0)
		{
			if(PlayerHealth.playerHealth == 0){
				auron.GetComponent<Rigidbody> ().Sleep ();
			
				m_Animator.SetBool("Dead",true);
				Invoke("callGameOver",5f);
			}
            if (BaseCarHealth.baseCarHealth == 0)
            {
                // auron.GetComponent<Rigidbody>().Sleep();

                // m_Animator.SetBool("Dead", true);
                GameOverFlag = true;
                Invoke("callGameOver", 5f);
            }


        }
	}

	void callGameOver(){
		Application.LoadLevel("GameOver");
	}

    void OnGUI()
    {
        if (GameOverFlag)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 100, 100), "Base Car Destroyed", mainFont);
        }
    }
}
