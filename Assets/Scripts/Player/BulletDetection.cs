using UnityEngine;
using System.Collections;

public class BulletDetection : MonoBehaviour {
	// Use this for initialization
	public int timeDelay = 2;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		/*timeDelay -= Time.deltaTime;
		if (timeDelay < 0) {
			PlayerGUI.batteryPerc --;
			timeDelay = 2;
		}*/
	
	}

		//Bullet collision
	void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
			PlayerGUI.batteryPerc +=5;
			EnemyManager.enemyKillCount--;
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
