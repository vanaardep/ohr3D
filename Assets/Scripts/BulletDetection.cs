using UnityEngine;
using System.Collections;

public class BulletDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

		//Bullet collision
	void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
