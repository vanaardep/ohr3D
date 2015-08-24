using UnityEngine;
using System.Collections;

public class PlayerTorch : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		string objectName = other.name.Replace("(Clone)", "");
		if (objectName == "ghoulprefab") 
			{
				other.GetComponent<Animator>().Play("idleEnemy");
				EnemyMove enemyScript = other.GetComponent<EnemyMove> ();
				enemyScript.freezeEnemy();
			}
	}
}
