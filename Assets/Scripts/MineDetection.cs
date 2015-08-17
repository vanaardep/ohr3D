using UnityEngine;
using System.Collections;

public class MineDetection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Mine collision
	void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
